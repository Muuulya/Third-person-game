using UnityEngine;

public class JumpAbility : AbilityBase
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Transform _transform;
    [SerializeField] private Animator _animator;
    
    [Header("Values")]
    [SerializeField] private float _jumpforce;

    protected override void StartAbility()
    {
        if (IsGrounded())
        {
            _animator.SetTrigger("Jump");
            _rigidbody.AddForce(Vector3.up * _jumpforce, ForceMode.Impulse);
        }
    }

    protected override void StopAbility()
    {
        
    }

    private bool IsGrounded()
    {
        Ray ray = new Ray(_transform.position + Vector3.up * 0.25f, Vector3.down);
        return Physics.Raycast(ray, out RaycastHit hit, 0.3f);
    }

}
