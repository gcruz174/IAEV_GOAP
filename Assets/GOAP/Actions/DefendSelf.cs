using UnityEngine;

namespace GOAP.Actions
{
    public class DefendSelf : GAction
    {
        [SerializeField]
        private bool walkTowardsEnemy = true;
        
        public override bool PrePerform()
        {
            gagent.ForgetLocationBeliefs();
            target = walkTowardsEnemy ? gagent.EnemyTarget : gameObject;
            return true;
        }

        public override bool PostPerform()
        {
            if (gagent.EnemyTarget == null) return false;
            var direction = gagent.EnemyTarget.transform.position - transform.position;
            gagent.Fire(direction);
            return true;
        }

        public void Update()
        {
            if (running && gagent.EnemyTarget != null && walkTowardsEnemy)
            {
                agent.SetDestination(gagent.EnemyTarget.transform.position);
            }
        }
    }
}
