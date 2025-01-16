using UnityEngine;
using UnityEngine.Serialization;

public class ResourcesIndicatorManager : MonoBehaviour
{
    [SerializeField]
    private GameObject resourcesIndicatorPrefab;
    
    private void OnEnable()
    {
        ResourcesComponent.OnResourcesComponentCreated += CreateResourcesIndicator;
    }
    
    private void OnDisable()
    {
        ResourcesComponent.OnResourcesComponentCreated -= CreateResourcesIndicator;
    }

    private void Start()
    {
        var enemies = FindObjectsByType<ResourcesComponent>(FindObjectsSortMode.None);
        foreach (var enemy in enemies)
        {
            CreateResourcesIndicator(enemy);
        }
    }
    
    private void CreateResourcesIndicator(ResourcesComponent target)
    {
        var resourcesIndicator = Instantiate(resourcesIndicatorPrefab, transform);
        resourcesIndicator.GetComponent<ResourceIndicator>().SetTarget(target);
    }
}
