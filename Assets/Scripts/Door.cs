using GOAP;
using UnityEngine;

public class Door : MonoBehaviour
{
    private HealthComponent _healthComponent;
    
    private void Awake()
    {
        _healthComponent = GetComponent<HealthComponent>();
    }
    
    private void OnEnable()
    {
        _healthComponent.OnDeath += OnDeath;
        _healthComponent.OnDamage += OnDamage;
        _healthComponent.OnHeal += OnHeal;
    }

    private void OnDisable()
    {
        _healthComponent.OnDeath -= OnDeath;
        _healthComponent.OnDamage -= OnDamage;
        _healthComponent.OnHeal -= OnHeal;
    }
    
    private static void OnDamage(int newHealth)
    {
        if (newHealth < 100)
            GWorld.GetWorld().ModifyState("doorDamaged", 1);
    }
    
    private static void OnHeal(int newHealth)
    {
        if (newHealth == 100)
            GWorld.GetWorld().RemoveState("doorDamaged");
    }
    
    private static void OnDeath()
    {
        GWorld.GetWorld().ModifyState("brokenDoors", 1);
    }
}
