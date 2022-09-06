using UnityEngine;
using UnityEngine.UI;

public class UICooldownAbility : MonoBehaviour
{
    [SerializeField] private Image _darkMask;
    [SerializeField] private Text _cooldownText;
    private float _cooldownTime;
    private float _cooldownTimeLeft;
    private float _abilityTimeLeft;

    private void Awake()
    {
        _cooldownText.enabled = false;
        _darkMask.enabled = false;
    }

    private void Update()
    {
        if (_cooldownTimeLeft > 0)
        {
            _cooldownTimeLeft -= Time.deltaTime;
            float roundedCooldownTime = Mathf.Round(_cooldownTimeLeft);
            _cooldownText.text = roundedCooldownTime.ToString();
            _darkMask.fillAmount = (_cooldownTimeLeft / _cooldownTime);
        }

        if (_abilityTimeLeft > 0)
        {
            _abilityTimeLeft -= Time.deltaTime;
            float roundedAbilityTime = Mathf.Round(_abilityTimeLeft);
            _cooldownText.text = roundedAbilityTime.ToString();
        }
    }

    public void StartCooldown(float value)
    {
        _cooldownTime = value;
        _cooldownTimeLeft = value;
        _darkMask.enabled = true;
        _cooldownText.enabled = true;
    }

    public void StartAbility(float value)
    {
        _abilityTimeLeft = value;
        _cooldownText.enabled = true;
    }
    
    public void ActivateButton()
    {
        _darkMask.enabled = false;
        _cooldownText.enabled = false;
        _darkMask.fillAmount = 1;
    }
}
