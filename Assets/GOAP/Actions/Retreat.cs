using UnityEngine;

namespace GOAP.Actions
{
    public class Retreat : GAction
    {
        public override bool PrePerform()
        {
            return true;
        }

        public override bool PostPerform()
        {
            var distanceToTarget = Vector3.Distance(target.transform.position, transform.position);
            if (distanceToTarget < distance)
            {
                Destroy(gameObject);
                return true;
            }
            return false;
        }
    }
}
