using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class AbilityBase : MonoBehaviour
{
    [Header("Input")] 
    [SerializeField] private InputActionReference _input;
    
    [Header("Time")]
    [SerializeField] private float _cooldownTime;
    [SerializeField] private float _abilityDurationTime;
    private bool _canUse = true;
    private InputAction _inputAction;
    
    [Header("Connections")]
    [SerializeField] private UICooldownAbility _uiCooldown;

    private void Awake()
    {
        _inputAction = _input.ToInputAction();
    }

    private void OnEnable()
    {
        _inputAction.started += TriggerAbility;
        _inputAction.Enable();
    }

    private void OnDisable()
    {
        _inputAction.started -= TriggerAbility;
        _inputAction.Disable();
    }

    private void TriggerAbility(InputAction.CallbackContext obj)
    {
        if (_canUse)
        {
            StartCoroutine(Ability());
        }
    }

    protected abstract void StartAbility();
    protected abstract void StopAbility();

    IEnumerator Ability()
    {
        _canUse = false;
        StartAbility();
        if(_abilityDurationTime > 0) _uiCooldown.StartAbility(_abilityDurationTime);
        yield return new WaitForSeconds(_abilityDurationTime);
        StopAbility();
        if(_cooldownTime > 0) _uiCooldown.StartCooldown(_cooldownTime);
        yield return new WaitForSeconds(_cooldownTime);
        _uiCooldown.ActivateButton();
        _canUse = true;
    }
}