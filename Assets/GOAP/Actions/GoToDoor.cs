using System;

namespace GOAP.Actions
{
    public class GoToDoor : GAction
    {
        public override bool PrePerform()
        {
            var isAtDoor = beliefs.HasState("isAtDoor");
            var brokenDoors = GWorld.GetWorld().HasState("brokenDoors");
            return !isAtDoor && !brokenDoors;
        }

        public override bool PostPerform()
        {
            inventory.AddItem(target);
            beliefs.ModifyState("isAtDoor", 1);
            return true;
        }
    }
}
