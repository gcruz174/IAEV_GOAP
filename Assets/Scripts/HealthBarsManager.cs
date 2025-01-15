using UnityEngine;

public class HealthBarsManager : MonoBehaviour
{
    [SerializeField]
    private GameObject healthBarPrefab;
    
    private void OnEnable()
    {
        HealthComponent.OnHealthComponentCreated += CreateHealthBar;
    }
    
    private void OnDisable()
    {
        HealthComponent.OnHealthComponentCreated -= CreateHealthBar;
    }

    private void Start()
    {
        var enemies = FindObjectsByType<HealthComponent>(FindObjectsSortMode.None);
        foreach (var enemy in enemies)
        {
            CreateHealthBar(enemy);
        }
    }
    
    private void CreateHealthBar(HealthComponent target)
    {
        var healthBar = Instantiate(healthBarPrefab, transform);
        healthBar.GetComponent<HealthBar>().SetTarget(target);
    }
}
