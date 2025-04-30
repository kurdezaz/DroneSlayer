using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SliderHealth : MonoBehaviour
{
    [SerializeField] private Slider _sliderHealth;
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private float _timeSlider = 0.1f;

    private float _healthChangeRate = 10f;
    private float _minChangeRate = 1f;
    private float _maxChangeRate;
    private float _currentPlayerHealth;
    private WaitForSeconds _wait;
    private Coroutine _sliderCoroutine;

    private void OnEnable()
    {
        _playerHealth.PlayerHealthChanged += DisplayValue;
    }

    private void OnDisable()
    {
        _playerHealth.PlayerHealthChanged -= DisplayValue;
        StopCoroutine(SliderDelay());
        _sliderCoroutine = null;
    }

    private void Start()
    {
        _wait = new WaitForSeconds(_timeSlider);
        _maxChangeRate = _playerHealth.MaxHealth;
        _currentPlayerHealth = _playerHealth.Health;
        _sliderHealth.minValue = _playerHealth.MinHealth;
        _sliderHealth.maxValue = _playerHealth.MaxHealth;
        _sliderHealth.value = _playerHealth.Health;
    }

    public void DisplayValue()
    {
        if (_sliderCoroutine == null && _currentPlayerHealth != _playerHealth.Health)
        {
            _sliderCoroutine = StartCoroutine(SliderDelay());
        }
    }

    private IEnumerator SliderDelay()
    {
        float playerHealth = _playerHealth.Health;
        _maxChangeRate = _playerHealth.MaxHealth;
        _sliderHealth.maxValue = _playerHealth.MaxHealth;

        while (_currentPlayerHealth != playerHealth)
        {
            yield return _wait;

            playerHealth = _playerHealth.Health;
            float changeRate = Mathf.Abs(_currentPlayerHealth - playerHealth) / _healthChangeRate;
            changeRate = Mathf.Clamp(changeRate, _minChangeRate, _maxChangeRate);
            _currentPlayerHealth = Mathf.MoveTowards(_currentPlayerHealth, playerHealth, changeRate);
            _sliderHealth.value = _currentPlayerHealth;
        }

        _sliderCoroutine = null;
    }
}
