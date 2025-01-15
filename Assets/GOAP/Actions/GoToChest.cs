using UnityEngine;

namespace GOAP.Actions
{
    public class GoToChest : GAction
    {
        [SerializeField] 
        private int arrowAmount = 10;
    
        public override bool PrePerform()
        {
            gagent.ForgetLocationBeliefs();
            return !beliefs.HasState("arrows");
        }

        public override bool PostPerform()
        {
            beliefs.ModifyState("arrows", arrowAmount);
            return true;
        }
    }
}
