using System.Collections.Generic;

namespace GOAP
{
    public class SubGoal
    {
        public readonly Dictionary<string, int> sgoals;
        public readonly bool remove;

        public SubGoal(string s, int i, bool r)
        {
            sgoals = new Dictionary<string, int> { { s, i } };
            remove = r;
        }
    }
}