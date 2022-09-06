using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private float _damage;

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Health>()?.TakeDamage(_damage);
    }
}