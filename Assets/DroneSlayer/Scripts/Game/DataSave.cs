using DroneSlayer.PlayerEntity;
using DroneSlayer.PlayerEntity.PlayerSkill;
using UnityEngine;
using YG;

namespace DroneSlayer.Game
{
    public class DataSave : MonoBehaviour
    {
        [SerializeField] private Wallet _wallet;
        [SerializeField] private PlayerHealth _playerHealth;
        [SerializeField] private Player _player;
        [SerializeField] private PlayerScore _playerScore;
        [SerializeField] private PlayerSkills _playerSkills;
        [SerializeField] private Weapons _weapons;

        private void OnEnable()
        {
            YandexGame.GetDataEvent += LoadData;
        }

        private void OnDisable()
        {
            YandexGame.GetDataEvent -= LoadData;
        }

        private void Start()
        {
            if (YandexGame.SDKEnabled == true)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            _wallet.LoadCash();
            _playerHealth.LoadHealth();
            _player.LoadPlayerLevel();
            _player.LoadPlayerExpirience();
            _playerScore.LoadPlayerScore();
            _playerSkills.LoadSkills();
            _weapons.LoadWeaponTypes();
        }
    }
}