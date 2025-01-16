
namespace GOAP.Agents
{
    public class Repairman : GAgent
    {
        private new void Start()
        {
            base.Start();
            var s1 = new SubGoal("getResources", 1, false);
            Goals.Add(s1, 1);
            
            var s2 = new SubGoal("repairDoor", 1, false);
            Goals.Add(s2, 3);
        }
    }
}
