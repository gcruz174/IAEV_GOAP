using System;

namespace GOAP.Actions
{
    public class GoToDoor : GAction
    {
        public override bool PrePerform()
        {
            return !beliefs.HasState("isAtDoor") && !GWorld.GetWorld().HasState("brokenDoors");
        }

        public override bool PostPerform()
        {
            inventory.AddItem(target);
            beliefs.ModifyState("isAtDoor", 1);
            return true;
        }
    }
}
