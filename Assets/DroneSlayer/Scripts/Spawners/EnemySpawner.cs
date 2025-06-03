using System.Collections;
using DroneSlayer.EnemyEntity;
using DroneSlayer.PlayerEntity;
using UnityEngine;

namespace DroneSlayer.Spawners
{
    public class EnemySpawner : Spawner<Enemy>
    {
        [SerializeField] private Player _player;
        [SerializeField] private PlayerScore _playerScore;
        [SerializeField] private PlayerHealth _playerHealth;
        [SerializeField] private Wallet _wallet;
        [SerializeField] private DroneArraysData _droneArraysData;
        [SerializeField] private AudioSource _soundExplosion;

        private float _delay = 3f;
        private int _enemyLevel = 0;
        private int _maxSpawnEnemyLevel = 11;

        private void Awake()
        {
            for (int i = 0; i<_prefabArray.Count; i++)
            {
                Init(_prefabArray[i]);
            }

            UpdateEnemySpawnLevel();
            StartCoroutine(SpawnEnemies());
        }

        public void PutEnemy(Enemy enemyPrefab)
        {
            _soundExplosion.Play();

            if (enemyPrefab.IsDied && enemyPrefab.IsCleared == false)
            {
                _wallet.GetMoney(enemyPrefab.CashAward);
            }

            enemyPrefab.DroneDied -= PutEnemy;
            enemyPrefab.gameObject.SetActive(false);

            if (enemyPrefab.IsCleared == false)
            {
                for (int i = 0; i < _prefabArray.Count; i++)
                {
                    if (_objectPool[i].Prefab.EnemyTypes == enemyPrefab.EnemyTypes)
                    {
                        _objectPool[i].PutObject(enemyPrefab);
                    }
                }
            }
        }

        private IEnumerator SpawnEnemies()
        {
            var wait = new WaitForSeconds(_delay);

            while (enabled)
            {
                for (int i = 0; i < _droneArraysData.DroneArrays[_enemyLevel].Enemies.Length; i++)
                {
                    CreateEnemy(_droneArraysData.DroneArrays[_enemyLevel].Enemies[i]);
                    yield return wait;
                }

                UpdateEnemySpawnLevel();
            }
        }

        private void CreateEnemy(Enemy enemyPrefab)
        {
            Enemy enemy = GetObject(enemyPrefab);
            enemy.Init(transform.position, _player, _playerHealth, _playerScore);
            enemy.DroneDied += PutEnemy;
        }

        private void UpdateEnemySpawnLevel()
        {
            _enemyLevel = _player.PlayerLevel - 1;

            if (_enemyLevel >= _maxSpawnEnemyLevel)
            {
                _enemyLevel = _maxSpawnEnemyLevel;
            }
        }
    }
}