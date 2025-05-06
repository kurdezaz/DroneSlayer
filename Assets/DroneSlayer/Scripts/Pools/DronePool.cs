using UnityEngine;
using DroneSlayer.EnemyEntity;
using DroneSlayer.PlayerEntity;

namespace DroneSlayer.Pools
{
    public class DronePool : ObjectPool<Enemy>
    {
        [SerializeField] private Enemy[] _enemies0Lvl;
        [SerializeField] private Enemy[] _enemies2Lvl;
        [SerializeField] private Enemy[] _enemies4Lvl;
        [SerializeField] private Enemy[] _enemies6Lvl;
        [SerializeField] private Enemy[] _enemies8Lvl;
        [SerializeField] private Enemy[] _enemies10Lvl;
        [SerializeField] private Enemy[] _enemies12Lvl;
        [SerializeField] private Player _player;

        private void OnEnable()
        {
            _player.LvlChanged += ChooseNewEnemies;
        }

        private void OnDisable()
        {
            _player.LvlChanged -= ChooseNewEnemies;
        }

        private void Awake()
        {
            InitQueue();
        }

        public void ChooseNewEnemies()
        {
            if (_player.PlayerLevel == 1)
            {
                FillEnemyData(_enemies0Lvl);
            }
            else if (_player.PlayerLevel >= 2 && _player.PlayerLevel < 4)
            {
                FillEnemyData(_enemies2Lvl);
            }
            else if (_player.PlayerLevel >= 4 && _player.PlayerLevel < 6)
            {
                FillEnemyData(_enemies4Lvl);
            }
            else if (_player.PlayerLevel >= 6 && _player.PlayerLevel < 8)
            {
                FillEnemyData(_enemies6Lvl);
            }
            else if (_player.PlayerLevel >= 8 && _player.PlayerLevel < 10)
            {
                FillEnemyData(_enemies8Lvl);
            }
            else if (_player.PlayerLevel >= 10 && _player.PlayerLevel < 12)
            {
                FillEnemyData(_enemies10Lvl);
            }
            else if (_player.PlayerLevel >= 12)
            {
                FillEnemyData(_enemies12Lvl);
            }
        }
    }
}