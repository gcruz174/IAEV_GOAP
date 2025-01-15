using UnityEngine;

namespace GOAP.Actions
{
    public class RepairDoor : GAction
    {
        private static readonly int Interact = Animator.StringToHash("Interact");
        
        public override bool PrePerform()
        {
            if (inventory.FindItemWithTag("DoorInside") == null || !beliefs.HasState("isAtDoor"))
            {
                return false;
            }
            target = inventory.FindItemWithTag("DoorInside");
            return true;
        }

        public override bool PostPerform()
        {
            var door = inventory.FindItemWithTag("DoorInside");
            if (door == null) return false;
            door.transform.parent.GetComponent<HealthComponent>().Heal(25);
            beliefs.ModifyState("isAtDoor", 0);
            beliefs.ModifyState("resources", -1);
            gagent.Animator.SetTrigger(Interact);
            return true;
        }
    }
}
