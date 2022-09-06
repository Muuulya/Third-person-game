using UnityEngine;

public class FirstAidKitBig : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Health>())
        {
            var health = other.GetComponent<Health>();
            if (!health.CurrentHealthIsFull())
            {
                health.FullHealtRecovery();
                Destroy(gameObject);
            }
        }
    }
}
