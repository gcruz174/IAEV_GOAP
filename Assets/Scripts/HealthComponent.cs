using System;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public int Health => health;
    
    [SerializeField]
    private int health = 100;
    private int _maxHealth = 100;
    
    public event Action<int> OnDamage;
    public event Action<int> OnHeal;
    public event Action OnDeath;
    
    public static event Action<HealthComponent> OnHealthComponentCreated;
    
    private void Awake()
    {
        OnHealthComponentCreated?.Invoke(this);
        _maxHealth = health;
    }

    public void Heal(int amount)
    {
        health += amount;
        if (health > _maxHealth)
            health = _maxHealth;
        OnHeal?.Invoke(health);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        OnDamage?.Invoke(health);
        if (health <= 0)
        {
            OnDeath?.Invoke();
            Destroy(gameObject);
        }
    }
}
