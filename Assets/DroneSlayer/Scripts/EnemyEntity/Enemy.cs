using System;
using System.Collections;
using UnityEngine;
using DroneSlayer.PlayerEntity;
using DroneSlayer.Effects;
using DroneSlayer.WeaponEntity;

namespace DroneSlayer.EnemyEntity
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyAttacked _enemyAttacked;
        [SerializeField] private ExplosiveDrone _explosive;

        [SerializeField] private float _expirienceOnDied;
        [SerializeField] private float _health = 100;
        [SerializeField] private float _damage = 10;
        [SerializeField] private int _cashAward = 20;
        [SerializeField] private long _score = 20;

        private Player _player;
        private PlayerScore _playerScore;
        private PlayerHealth _playerHealth;

        private float _timeToTakeDamage = 0.1f;
        private float _flightSpeed = 1f;
        private bool _isDied = false;
        private float _currentHealth;
        private float _minHealth = 0;
        private float _baseHealth = 100f;
        private float _hpCoefficient = 0.1f;

        public int CashAward => _cashAward;
        public float MinHealth => _minHealth;
        public float MaxHealth => _health;
        public float Health => _currentHealth;
        public bool IsDied => _isDied;

        public bool IsCleared { get; private set; } = false;

        public event Action<Enemy> DiedEventDrone;
        public event Action<float> HealthChanged;

        private void OnEnable()
        {
            _currentHealth = _health;
            _isDied = false;
        }

        private void OnDisable()
        {
            _enemyAttacked.ChangeColorStandart();
        }

        private void Awake()
        {
            _baseHealth = _health;
        }

        private void Update()
        {
            transform.Translate(0, 0, _flightSpeed * Time.deltaTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out Bullet bullet))
            {
                TakeDamage(bullet.Damage);

                if (_isDied != true)
                {
                    StartCoroutine(EffectTakeDamage());
                }
                else
                {
                    _player.GainExpirience(_expirienceOnDied);
                    _playerScore.GainScore(_score);
                    Death();

                    DiedEventDrone?.Invoke(this);
                }
            }

            if (other.gameObject.TryGetComponent(out DroneWall droneWall))
            {
                _playerHealth.TakeDamage(_damage);
                DiedEventDrone?.Invoke(this);
            }
        }

        public void Init(Vector3 vector3, Player player, PlayerHealth health, PlayerScore score)
        {
            gameObject.SetActive(true);

            float minRange = -3;
            float maxRange = 3;

            float randomizeZ = UnityEngine.Random.Range(minRange, maxRange);

            transform.position = new Vector3(vector3.x, vector3.y, vector3.z + randomizeZ);
            _player = player;
            _playerHealth = health;
            _playerScore = score;
            _player.LvlChanged += ClearDrone;

            ChangeHealth();
            _currentHealth = _health;
        }

        public void TakeDamage(float damage)
        {
            _currentHealth -= damage;

            if (_currentHealth <= 0)
            {
                _isDied = true;
                _currentHealth = _health;
            }
            else
            {
                HealthChanged?.Invoke(_currentHealth);
            }
        }

        public void Death()
        {
            var explosion = Instantiate(_explosive);
            explosion.transform.position = transform.position;
        }

        private void ChangeHealth()
        {
            _health = _baseHealth;
            _health += _health * _hpCoefficient * _player.PlayerLevel;
        }

        private void ClearDrone()
        {
            if (_player.PlayerLevel % 1 == 0 && gameObject.activeSelf)
            {
                _isDied = true;
                Death();
                _player.LvlChanged -= ClearDrone;
                IsCleared = true;
                DiedEventDrone?.Invoke(this);
            }


        }

        private IEnumerator EffectTakeDamage()
        {
            if (enabled)
            {
                float timeDelay = _timeToTakeDamage;
                var wait = new WaitForSeconds(timeDelay);
                _enemyAttacked.ChangeColorWhite();
                yield return wait;
                _enemyAttacked.ChangeColorStandart();
            }
        }
    }
}