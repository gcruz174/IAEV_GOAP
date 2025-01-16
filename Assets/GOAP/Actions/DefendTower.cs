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
            var enemy = gagent.EnemyNear(shootRange);
            if (enemy == null) return false;
            var direction = enemy.transform.position - transform.position;
            var rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 10);
            gagent.Fire(direction);
            return true;
        }
    }
}
