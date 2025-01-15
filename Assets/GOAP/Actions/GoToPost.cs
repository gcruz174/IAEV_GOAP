namespace GOAP.Actions
{
    public class GoToPost : GAction
    {
        public override bool PrePerform()
        {
            var post = GWorld.RemoveNearestDefensePost(transform.position);
            if (post == null) return false;
            inventory.AddItem(post);
            target = post;
            return true;
        }

        public override bool PostPerform()
        {
            beliefs.AddState("isAtDefensePost", 1);
            return true;
        }
    }
}
