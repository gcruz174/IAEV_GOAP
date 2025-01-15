using UnityEngine;

namespace GOAP.Actions
{
    public class DamageFlag : GAction
    {
        private static readonly int Attack = Animator.StringToHash("Attack");

        public override bool PrePerform()
        {
            if (inventory.FindItemWithTag("Flag") == null || !beliefs.HasState("isAtFlag"))
            {
                return false;
            }
            target = inventory.FindItemWithTag("Flag");
            return true;
        }

        public override bool PostPerform()
        {
            var flag = inventory.FindItemWithTag("Flag");
            if (flag == null) return false;
            flag.transform.GetComponent<HealthComponent>().TakeDamage(5);
            gagent.Animator.SetTrigger(Attack);
            return true;
        }
    }
}
