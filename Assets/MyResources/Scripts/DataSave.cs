using UnityEngine;
using YG;

public class DataSave : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private Player _player;
    [SerializeField] private PlayerScore _playerScore;
    [SerializeField] private DronePool _dronePool;
    [SerializeField] private PlayerSkills _playerSkills;
    [SerializeField] private Weapons _weapons;

    private void OnEnable()
    {
        YandexGame.GetDataEvent += GetLoad;
    }

    private void OnDisable()
    {
        YandexGame.GetDataEvent -= GetLoad;
    }

    private void Start()
    {
        if (YandexGame.SDKEnabled == true)
        {
            GetLoad();
        }
    }

    private void GetLoad()
    {
        _wallet.LoadCash();
        _playerHealth.LoadHealth();
        _player.LoadPlayerLevel();
        _dronePool.ChooseNewEnemies();
        _player.LoadPlayerExpirience();
        _playerScore.LoadPlayerScore();
        _playerSkills.LoadSkills();
        _weapons.LoadWeaponTypes();
    }
}
