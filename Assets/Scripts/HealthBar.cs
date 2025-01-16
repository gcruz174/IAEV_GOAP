using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private HealthComponent _target;
    private Slider _slider;

    private void Update()
    {
        // project target to screen space and set position of health bar with offset
        if (_target == null)
        {
            Destroy(gameObject);
            return;
        }
        
        var screenPos = Camera.main.WorldToScreenPoint(_target.transform.position);
        transform.position = screenPos + new Vector3(0, 50, 0);
        _slider.value = _target.Health;
    }

    public void SetTarget(HealthComponent target)
    {
        _slider = GetComponent<Slider>();
        _target = target;
        _slider.maxValue = target.Health;
    }
}