namespace GOAP.Actions
{
    public class GoToFlag : GAction
    {
        public override bool PrePerform()
        {
            return GWorld.GetWorld().HasState("brokenDoors");
        }

        public override bool PostPerform()
        {
            inventory.AddItem(target);
            beliefs.ModifyState("isAtFlag", 1);
            return true;
        }
    }
}
