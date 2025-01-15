using UnityEngine;

namespace GOAP
{
    [ExecuteInEditMode]
    public class GAgentVisual : MonoBehaviour
    {
        public GAgent thisAgent;

        private void Start()
        {
            thisAgent = GetComponent<GAgent>();
        }
    }
}
