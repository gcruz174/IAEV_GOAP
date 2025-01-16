using System;
using GOAP;
using UnityEngine;

public class ResourcesComponent : MonoBehaviour
{
    [SerializeField] public string beliefName;
    [SerializeField] public Sprite beliefIcon;
    
    public Sprite ResourceIcon => beliefIcon;
    public int ResourceCount => 
        _gAgent.Beliefs.HasState(beliefName) ? _gAgent.Beliefs.GetStates()[beliefName] : 0;
    
    public static event Action<ResourcesComponent> OnResourcesComponentCreated;

    private GAgent _gAgent;
    
    private void Awake()
    {
        OnResourcesComponentCreated?.Invoke(this);
        _gAgent = GetComponent<GAgent>();
    }
}
