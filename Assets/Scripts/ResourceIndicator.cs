using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResourceIndicator : MonoBehaviour
{
    [SerializeField]
    private TMP_Text text;
    [SerializeField] 
    private Image icon;
    
    private ResourcesComponent _target;

    private void Update()
    {
        // project target to screen space and set position of health bar with offset
        if (_target == null)
        {
            Destroy(gameObject);
            return;
        }
        
        var screenPos = Camera.main.WorldToScreenPoint(_target.transform.position);
        transform.position = screenPos + new Vector3(0, 80, 0);
        
        var count = _target.ResourceCount;
        text.gameObject.SetActive(count > 0);
        text.text = "x " + count;
        icon.gameObject.SetActive(count > 0);
    }

    public void SetTarget(ResourcesComponent target)
    {
        _target = target;
        icon.sprite = target.ResourceIcon;
    }
}
