using UnityEngine;

public class MakeRubberBullet : MonoBehaviour
{
    [SerializeField] private GameObject _rubberBullet;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.GetComponent<ShootAbility>())
        {
            var ability = other.GetComponent<ShootAbility>();
            ability.SetBullet(_rubberBullet);
            Destroy(gameObject);
        }
    }
}
