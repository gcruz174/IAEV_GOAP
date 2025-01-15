using UnityEngine;

namespace GOAP.Actions
{
    public class DamageDoor : GAction
    {
        private static readonly int Attack = Animator.StringToHash("Attack");

        public override bool PrePerform()
        {
            if (inventory.FindItemWithTag("Door") == null || !beliefs.HasState("isAtDoor"))
            {
                return false;
            }
            target = inventory.FindItemWithTag("Door");
            return true;
        }

        public override bool PostPerform()
        {
            var door = inventory.FindItemWithTag("Door");
            if (door == null) return false;
            gagent.Animator.SetTrigger(Attack);
            door.transform.parent.GetComponent<HealthComponent>().TakeDamage(5);
            return true;
        }
    }
}
