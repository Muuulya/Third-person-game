using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _bulletForce;
    [SerializeField] private float _destroyTime = 10;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = this.GetComponent<Rigidbody>();
    }

    void Start()
    {
        _rigidbody.AddForce(this.transform.forward * _bulletForce, ForceMode.Impulse);
        StartCoroutine(DestroyTimer());
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    IEnumerator DestroyTimer()
    {
        yield return new WaitForSeconds(_destroyTime);
        Destroy(gameObject);
    }
}
