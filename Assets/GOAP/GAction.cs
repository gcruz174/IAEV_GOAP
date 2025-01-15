using System.Collections.Generic;
using GOAP;
using UnityEngine;
using UnityEngine.AI;

public abstract class GAction : MonoBehaviour
{
    public string actionName = "Action";
    public float cost = 1.0f;
    public GameObject target;
    public string targetTag;
    public float duration = 0;
    public float distance = 0.5f;
    public WorldState[] preConditions;
    public WorldState[] afterEffects;
    public GAgent gagent;
    public NavMeshAgent agent;

    public Dictionary<string, int> preconditions = new();
    public Dictionary<string, int> effects = new();

    protected GInventory inventory;
    protected WorldStates beliefs;

    public bool running;

    public void Awake()
    {
        gagent = gameObject.GetComponent<GAgent>();
        agent = gameObject.GetComponent<NavMeshAgent>();

        if (preConditions != null)
        {
            foreach (var w in preConditions)
            {
                preconditions.Add(w.key, w.value);
            }
        }


        if (afterEffects != null)
        {
            foreach (var w in afterEffects)
            {
                effects.Add(w.key, w.value);
            }
        }
        
        inventory = GetComponent<GAgent>().Inventory;
        beliefs = GetComponent<GAgent>().Beliefs;
    }

    public bool IsAchievable()
    {
        return true;
    }

    public bool IsAchievableGiven(Dictionary<string, int> conditions)
    {
        foreach (KeyValuePair<string, int> p in preconditions)
        {
            if (!conditions.ContainsKey(p.Key))
                return false;
        }
        return true;
    }

    public abstract bool PrePerform();
    public abstract bool PostPerform();
}