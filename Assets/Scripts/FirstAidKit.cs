using UnityEngine;

public class FirstAidKit : MonoBehaviour
{
    [SerializeField] private float _healthRecovery;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Health>())
        {
            var health = other.GetComponent<Health>();
            if (!health.CurrentHealthIsFull())
            {
                other.GetComponent<Health>().HealthRecovery(_healthRecovery);
                Destroy(gameObject);
            }
        }
    }
}
