using GOAP;
using UnityEngine;

public class Flag : MonoBehaviour
{
    private HealthComponent _healthComponent;
    
    private void Awake()
    {
        _healthComponent = GetComponent<HealthComponent>();
    }
    
    private void OnEnable()
    {
        _healthComponent.OnDeath += OnDeath;
    }

    private void OnDisable()
    {
        _healthComponent.OnDeath -= OnDeath;
    }
    
    private static void OnDeath()
    {
        GWorld.GetWorld().ModifyState("brokenFlags", 1);
    }
}
