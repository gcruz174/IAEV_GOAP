using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private HealthComponent target;

    private Slider _slider;

    private void Update()
    {
        // project target to screen space and set position of health bar with offset
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        
        var screenPos = Camera.main.WorldToScreenPoint(target.transform.position);
        transform.position = screenPos + new Vector3(0, 50, 0);
        _slider.value = target.Health;
    }

    public void SetTarget(HealthComponent target)
    {
        _slider = GetComponent<Slider>();
        this.target = target;
        _slider.maxValue = target.Health;
    }
}