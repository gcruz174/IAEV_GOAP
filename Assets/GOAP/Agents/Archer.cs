using UnityEngine;

namespace GOAP.Agents
{
    public class Archer : GAgent
    {
        [SerializeField] 
        private GameObject arrowPrefab;

        public override void ForgetLocationBeliefs()
        {
            base.ForgetLocationBeliefs();
            var tower = Inventory.FindItemWithTag("ArcherTower");
            if (tower == null) return;
            Inventory.RemoveItem(tower);
            GWorld.AddArcherTower(tower);
            Beliefs.RemoveState("isAtArcherTower");
        }

        public override void Fire(Vector3 direction)
        {
            if (!Beliefs.HasState("arrows")) return;
            base.Fire(direction);
            var position = transform.position;
            var arrow = Instantiate(arrowPrefab, position, Quaternion.identity);
            arrow.transform.LookAt(position + direction);
            Beliefs.ModifyState("arrows", -1);
        }

        private new void Start()
        {
            base.Start();
            var s1 = new SubGoal("defendTower", 1, false);
            Goals.Add(s1, 1);
            
            var s2 = new SubGoal("defendSelf", 1, false);
            Goals.Add(s2, 3);
        }
    }
}
