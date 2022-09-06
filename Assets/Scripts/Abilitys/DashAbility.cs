using UnityEngine;

public class DashAbility : AbilityBase
{
    [SerializeField] private ThirdPersonController _controller;
    
    [Header("Values")]
    [SerializeField] private float _dashSpeed;
    
    private float _normalSpeed;
    
    protected override void StartAbility()
    {
        _normalSpeed = _controller.maxSpeed;
        _controller.maxSpeed = _dashSpeed;
    }

    protected override void StopAbility()
    {
        _controller.maxSpeed = _normalSpeed;
    }
}