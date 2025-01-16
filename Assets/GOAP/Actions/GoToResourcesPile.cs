using UnityEngine;

namespace GOAP.Actions
{
    public class GoToResourcesPile : GAction
    {
        private static readonly int Interact = Animator.StringToHash("Interact");

        public override bool PrePerform()
        {
            return !beliefs.HasState("resources");
        }

        public override bool PostPerform()
        {
            gagent.Animator.SetTrigger(Interact);
            beliefs.ModifyState("resources", 1);
            return true;
        }
    }
}
