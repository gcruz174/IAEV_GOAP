using System.Collections.Generic;

namespace GOAP
{
    public class Node
    {

        public Node parent;
        public float cost;
        public Dictionary<string, int> state;
        public GAction action;

        // Constructor
        public Node(Node parent, float cost, Dictionary<string, int> allStates, GAction action)
        {

            this.parent = parent;
            this.cost = cost;
            this.state = new Dictionary<string, int>(allStates);
            this.action = action;
        }
        
        public Node(Node parent, float cost, Dictionary<string, int> allStates, Dictionary<string, int> beliefstates, GAction action)
        {

            this.parent = parent;
            this.cost = cost;
            this.state = new Dictionary<string, int>(allStates);
            foreach (KeyValuePair<string, int> b in beliefstates)
                if (!this.state.ContainsKey(b.Key))
                    this.state.Add(b.Key, b.Value);
            this.action = action;
        }
    }

}