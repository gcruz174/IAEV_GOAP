using UnityEngine;

namespace GOAP.Actions
{
    public class GoToArcherTower : GAction
    {
        public override bool PrePerform()
        {
            target = GWorld.RemoveArcherTower();
            if (target == null) return false;
            inventory.AddItem(target);
            return true;
        }

        public override bool PostPerform()
        {
            beliefs.AddState("isAtArcherTower", 1);
            return true;
        }
    }
}
