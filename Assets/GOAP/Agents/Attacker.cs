using UnityEngine;

namespace GOAP.Agents
{
    public class Attacker : GAgent
    {
        public override void ForgetLocationBeliefs()
        {
            base.ForgetLocationBeliefs();
            Beliefs.RemoveState("isAtDoor");
            Beliefs.RemoveState("isAtFlag");
        }

        public override void Fire(Vector3 direction)
        {
            base.Fire(direction);
            EnemyTarget.GetComponent<HealthComponent>().TakeDamage(25);
        }

        private new void Start()
        {
            base.Start();
            var s1 = new SubGoal("defendSelf", 1, false);
            Goals.Add(s1, 3);
            
            var s2 = new SubGoal("brokenFlags", 1, false);
            Goals.Add(s2, 1);
        }
    }
}
