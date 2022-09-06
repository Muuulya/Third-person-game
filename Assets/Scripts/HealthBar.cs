using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{ 
    [SerializeField] private Slider _slider;
    [SerializeField] private Text _healthText;
    
    public void SetHealth(float health)
    {
        _slider.value = health;
        _healthText.text = health.ToString();
    }

    public void SetMaxHealth(float maxHealth)
    {
        _slider.maxValue = maxHealth;
        _slider.value = maxHealth;
        _healthText.text = maxHealth.ToString();
    }
}
