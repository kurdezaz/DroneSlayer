using UnityEngine;
using UnityEngine.UI;

public class SliderHealthEnemy : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Enemy _enemy;

    private void OnEnable()
    {
        _enemy.HealthChanged += DisplayValue;

        _slider.minValue = _enemy.MinHealth;
        _slider.maxValue = _enemy.MaxHealth;
        _slider.value = _enemy.Health;
    }

    private void OnDisable()
    {
        _enemy.HealthChanged -= DisplayValue;
    }

    private void Start()
    {
        _slider.minValue = _enemy.MinHealth;
        _slider.maxValue = _enemy.MaxHealth;
        _slider.value = _enemy.Health;
    }

    private void DisplayValue(float health)
    {
        _slider.value = _enemy.Health;
    }
}
