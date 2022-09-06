using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonController : MonoBehaviour
{    
    
    public float maxSpeed = 5f;

    [SerializeField] private float _movementForce = 1f;
    [SerializeField] private Camera _playerCamera;
    
    private PlayerControls _playerControls;
    private InputAction _move;
    private Rigidbody _rigidbody;
    private Vector3 _forceDirection = Vector3.zero;
    private float _timerJerkDelay = float.MinValue;

    private void Awake()
    {
        _rigidbody = this.GetComponent<Rigidbody>();
        _playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        _move = _playerControls.Player.Move;
        _playerControls.Player.Enable();
    }

    private void OnDisable()
    {
        _playerControls.Player.Disable();
    }

    private void FixedUpdate()
    {
        _forceDirection += GetCameraRight(_playerCamera) * (_move.ReadValue<Vector2>().x * _movementForce);
        _forceDirection += GetCameraForward(_playerCamera) * (_move.ReadValue<Vector2>().y * _movementForce);

        _rigidbody.AddForce(_forceDirection, ForceMode.Impulse);
        _forceDirection = Vector3.zero;

        if (_rigidbody.velocity.y < 0f)
            _rigidbody.velocity -= Vector3.down * (Physics.gravity.y * Time.fixedDeltaTime);

        Vector3 horizontalVelocity = _rigidbody.velocity;
        horizontalVelocity.y = 0;
        if (horizontalVelocity.sqrMagnitude > maxSpeed * maxSpeed)
            _rigidbody.velocity = horizontalVelocity.normalized * maxSpeed + Vector3.up * _rigidbody.velocity.y;

        LookAt();
    }

    private void LookAt()
    {
        Vector3 direction = _rigidbody.velocity;
        direction.y = 0f;
        if (_move.ReadValue<Vector2>().sqrMagnitude > 0.1f && direction.sqrMagnitude > 0.1f)
            this._rigidbody.rotation = Quaternion.LookRotation(direction, Vector3.up);
        else
            _rigidbody.angularVelocity = Vector3.zero;
    }
    
    private Vector3 GetCameraForward(Camera camera)
    {
        var forward = camera.transform.forward;
        forward.y = 0;
        return forward.normalized;
    }

    private Vector3 GetCameraRight(Camera camera)
    {
        var right = camera.transform.right;
        right.y = 0;
        return right.normalized;
    }
}