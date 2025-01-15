using UnityEngine;

namespace GOAP.Agents
{
    public class Tank : GAgent
    {
        public override void Fire(Vector3 direction)
        {
            base.Fire(direction);
            EnemyTarget.GetComponent<HealthComponent>().TakeDamage(50);
        }

        private new void Start()
        {
            base.Start();
            var s1 = new SubGoal("retreat", 1, false);
            Goals.Add(s1, 3);
            
            var s2 = new SubGoal("hitDoor", 1, false);
            Goals.Add(s2, 1);
        }
    }
}
