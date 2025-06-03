using System;
using UnityEngine;
using YG;

namespace DroneSlayer.PlayerEntity
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private PlayerScore _playerScore;
        [SerializeField] private float _maxHealth;

        public event Action PlayerHealthChanged;

        public event Action PlayerDeathReached;

        public float Health { get; private set; } = 1;
        public float MinHealth { get; private set; } = 0;
        public float MaxHealth => _maxHealth;

        public void TakeDamage(float damage)
        {
            Health -= damage;
            YandexGame.savesData.health = Health;
            PlayerHealthChanged?.Invoke();

            if (Health <= 0)
            {
                YandexGame.NewLeaderboardScores("DroneSlayerLeaderBoard", _playerScore.Score);
                PlayerDeathReached?.Invoke();
            }
        }

        public void LoadHealth()
        {
            Health = (YandexGame.savesData.health <= 0) ? _maxHealth : YandexGame.savesData.health;
        }
    }
}
