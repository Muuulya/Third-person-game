using UnityEngine;

public class ThirdPersonAnimation : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody _rigidbody;
    [SerializeField] private float _maxSpeed = 5f;
    
    void Start()
    {
        _animator = this.GetComponent<Animator>();
        _rigidbody = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        var velocity = new Vector2();
        velocity.x = _rigidbody.velocity.x;
        velocity.y = _rigidbody.velocity.z;
        _animator.SetFloat("Speed", velocity.magnitude / (_maxSpeed * 2));
    }
}
