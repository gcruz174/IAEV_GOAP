using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

namespace GOAP
{
    public class GAgent : MonoBehaviour
    {
        [SerializeField] 
        private LayerMask enemyLayerMask;
        [SerializeField]
        private float selfDefenseRange = 3.5f;
        [SerializeField]
        private LayerMask lineOfSightMask;

        private static readonly int Attack = Animator.StringToHash("Attack");
        private static readonly int Moving = Animator.StringToHash("Moving");

        public WorldStates Beliefs { get; } = new();
        public GInventory Inventory { get; } = new();
        public Dictionary<SubGoal, int> Goals { get; } = new();

        public List<GAction> Actions { get; } = new();
        public NavMeshAgent NavMeshAgent { get; private set; }
        public GPlanner Planner { get; private set; }
        public Queue<GAction> ActionQueue { get; private set; }
        public GAction CurrentAction { get; private set; }
        public SubGoal CurrentGoal { get; private set; }
        public bool Invoked { get; private set; }
        public GameObject EnemyTarget { get; set; }
        public Animator Animator { get; set; }
        
        public GameObject EnemyNear(float range)
        {
            var enemies = Physics.OverlapSphere(transform.position, range, enemyLayerMask);
            var orderedEnemies = enemies.OrderBy(enemy => Vector3.Distance(enemy.transform.position, transform.position));
            return orderedEnemies.FirstOrDefault(enemy =>
                Vector3.Distance(enemy.transform.position, transform.position) < range &&
                !Physics.Linecast(transform.position, enemy.transform.position, lineOfSightMask))?.gameObject;
        }

        public virtual void ForgetLocationBeliefs() { }

        public virtual void Fire(Vector3 direction)
        {
            Animator.SetTrigger(Attack);
        }

        public void Start()
        {
            Animator = transform.GetChild(0).GetComponent<Animator>();
            NavMeshAgent = GetComponent<NavMeshAgent>();
            var actions = GetComponents<GAction>();
            foreach (var action in actions)
                Actions.Add(action);
        }
    
        private void CompleteAction()
        {
            CurrentAction.running = false;
            CurrentAction.PostPerform();
            Invoked = false;
        }

        private void LateUpdate()
        {
            Animator.SetBool(Moving, NavMeshAgent.velocity.magnitude > 0.1f);
            
            // update if enemies are nearby for defending
            EnemyTarget = EnemyNear(selfDefenseRange);
            if (EnemyTarget != null && !Beliefs.HasState("enemyNear"))
                Beliefs.AddState("enemyNear", 1);
            else if (EnemyTarget == null && Beliefs.HasState("enemyNear"))
                Beliefs.RemoveState("enemyNear");
            
            if (NavMeshAgent.velocity.magnitude > 0.1f)
            {
                // Look at target
                var lookPos = NavMeshAgent.steeringTarget - transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 10);
            }
            
            if (CurrentAction != null && CurrentAction.running && CurrentAction.target != null)
            {
                // si el navmesh no está calculando bien el remaining distance, se puede
                //calcular la distancia a mano.
                var distanceToTarget = Vector3.Distance(CurrentAction.target.transform.position, transform.position);
                if (distanceToTarget < CurrentAction.distance && !Invoked)
                {
                    Invoke(nameof(CompleteAction), CurrentAction.duration);
                    Invoked = true;
                }
                if (!Beliefs.HasState("enemyNear"))
                    return;
            }

            if (Planner == null || ActionQueue == null)
            {
                Planner = new GPlanner();

                var sortedGoals = from entry in Goals orderby entry.Value descending select entry;
                foreach (var subGoal in sortedGoals)
                {
                    ActionQueue = Planner.plan(Actions, subGoal.Key.sgoals, Beliefs);
                    if (ActionQueue == null) continue;
                    CurrentGoal = subGoal.Key;
                    break;
                }
            }

            if (ActionQueue is { Count: 0 })
            {
                if (CurrentGoal.remove)
                    Goals.Remove(CurrentGoal);
                Planner = null;
            }

            if (ActionQueue is { Count: > 0 })
            {
                CurrentAction = ActionQueue.Dequeue();
                // CancelInvoke();
                // Invoked = false;
                if (CurrentAction.PrePerform())
                {
                    if (CurrentAction.target == null && CurrentAction.targetTag != "")
                        CurrentAction.target = GameObject.FindWithTag(CurrentAction.targetTag);

                    if (CurrentAction.target != null)
                    {
                        CurrentAction.running = true;
                        CurrentAction.agent.SetDestination(CurrentAction.target.transform.position);
                    }
                }
                else
                {
                    ActionQueue = null;
                }
            }
        }
    }
}