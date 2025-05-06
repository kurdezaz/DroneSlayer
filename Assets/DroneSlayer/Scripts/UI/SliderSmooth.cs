using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace DroneSlayer.UI
{
    public class SliderSmooth : BarView
    {
        [SerializeField] private Slider _sliderSmooth;
        [SerializeField] private float _timeSlider = 0.1f;

        private float _expChangeRate = 10f;
        private float _minChangeRate = 1f;
        private float _maxChangeRate;
        private float _currentPlayerExpirience;
        private WaitForSeconds _wait;
        private Coroutine _sliderCoroutine;

        private void OnDisable()
        {
            StopCoroutine(SliderDelay());
            _sliderCoroutine = null;
        }

        private void Start()
        {
            _wait = new WaitForSeconds(_timeSlider);
            _maxChangeRate = _playerExpirience.MaxExpirience;
            _currentPlayerExpirience = _playerExpirience.Expirience;
            _sliderSmooth.minValue = _playerExpirience.MinExpirience;
            _sliderSmooth.maxValue = _playerExpirience.MaxExpirience;
            _sliderSmooth.value = _playerExpirience.Expirience;
            DisplayValue();
        }

        public override void DisplayValue()
        {
            if (_sliderCoroutine == null && _currentPlayerExpirience != _playerExpirience.Expirience)
            {
                _sliderCoroutine = StartCoroutine(SliderDelay());
            }
        }

        private IEnumerator SliderDelay()
        {
            float playerExpirience = _playerExpirience.Expirience;
            _maxChangeRate = _playerExpirience.MaxExpirience;
            _sliderSmooth.maxValue = _playerExpirience.MaxExpirience;

            while (_currentPlayerExpirience != playerExpirience)
            {
                yield return _wait;

                playerExpirience = _playerExpirience.Expirience;
                float changeRate = Mathf.Abs(_currentPlayerExpirience - playerExpirience) / _expChangeRate;
                changeRate = Mathf.Clamp(changeRate, _minChangeRate, _maxChangeRate);
                _currentPlayerExpirience = Mathf.MoveTowards(_currentPlayerExpirience, playerExpirience, changeRate);
                _sliderSmooth.value = _currentPlayerExpirience;
            }

            _sliderCoroutine = null;
        }
    }
}