using UnityEngine;

namespace GOAP.Agents
{
    public class Guard : GAgent
    {
        public override void ForgetLocationBeliefs()
        {
            base.ForgetLocationBeliefs();
            var post = Inventory.FindItemWithTag("DefensePost");
            if (post == null) return;
            Inventory.RemoveItem(post);
            GWorld.AddDefensePost(post);
            Beliefs.RemoveState("isAtDefensePost");
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
            
            var s2 = new SubGoal("defendPost", 1, false);
            Goals.Add(s2, 1);
        }
    }
}
