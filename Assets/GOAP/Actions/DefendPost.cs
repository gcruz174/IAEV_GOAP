namespace GOAP.Actions
{
    public class DefendPost : GAction
    {
        public override bool PrePerform()
        {
            return beliefs.HasState("isAtDefensePost");
        }

        public override bool PostPerform()
        {
            return true;
        }
    }
}
