using UnityEngine;

namespace GOAP.Actions
{
    public class DefendTower : GAction
    {
        [SerializeField] 
        private float shootRange = 10f;
        
        public override bool PrePerform()
        {
            var tower = inventory.FindItemWithTag("ArcherTower");
            target = tower;
            return gagent.EnemyNear(shootRange) != null;
        }

        public override bool PostPerform()
        {
            if (gagent.EnemyNear(shootRange) == null) return false;
            var direction = gagent.EnemyNear(shootRange).transform.position - transform.position;
            gagent.Fire(direction);
            return true;
        }
    }
}
