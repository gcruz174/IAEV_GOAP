using System;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;
    [SerializeField]
    private float lifeTime = 5f;
    
    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * (speed * Time.deltaTime));
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out HealthComponent healthComponent))
        {
            healthComponent.TakeDamage(25);
        }
        Destroy(gameObject);
    }
}
