using System.Collections;
using UnityEngine;
using DroneSlayer.EnemyEntity;
using DroneSlayer.PlayerEntity;

namespace DroneSlayer.Spawners
{
    public class EnemySpawner : Spawner<Enemy>
    {
        [SerializeField] private Enemy _enemyPrefab;
        [SerializeField] private Player _player;
        [SerializeField] private PlayerScore _playerScore;
        [SerializeField] private PlayerHealth _playerHealth;
        [SerializeField] private Wallet _wallet;
        [SerializeField] private AudioSource _soundExplosion;

        private float _delay = 3f;

        private void Awake()
        {
            StartCoroutine(SpawnEnemies());
        }

        private IEnumerator SpawnEnemies()
        {
            var wait = new WaitForSeconds(_delay);

            while (enabled)
            {
                CreateEnemy();
                yield return wait;
            }
        }

        private void CreateEnemy()
        {
            Enemy enemy = GetObject(_objectPool.ReturnQueue(), _enemyPrefab);
            enemy.Init(transform.position, _player, _playerHealth, _playerScore);
            enemy.DiedEventDrone += PutEnemy;
        }

        public void PutEnemy(Enemy enemyPrefab)
        {
            _soundExplosion.Play();

            if (enemyPrefab.IsDied && enemyPrefab.IsCleared == false)
            {
                _wallet.GetMoney(enemyPrefab.CashAward);
            }

            enemyPrefab.DiedEventDrone -= PutEnemy;
            enemyPrefab.gameObject.SetActive(false);

            if (enemyPrefab.IsCleared == false)
            {
                _objectPool.PutObject(enemyPrefab);
            }
        }
    }
}