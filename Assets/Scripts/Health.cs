using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100;
    [SerializeField] private HealthBar _healthBar;
    private float _currentHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;
        _healthBar.SetMaxHealth(_maxHealth);
    }

    private void Update()
    {
        _healthBar.SetHealth(_currentHealth);
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        if (_currentHealth < 0)
            _currentHealth = 0;
    }

    public void HealthRecovery(float healthRecovery)
    {
        if (_currentHealth != _maxHealth)
        {
            _currentHealth += healthRecovery;
            if (_currentHealth > _maxHealth)
                _currentHealth = _maxHealth;
        }
    }

    public void FullHealtRecovery()
    {
        if(_currentHealth != _maxHealth)
            _currentHealth = _maxHealth;
    }

    public bool CurrentHealthIsFull()
    {
        return _currentHealth == _maxHealth;
    }
}