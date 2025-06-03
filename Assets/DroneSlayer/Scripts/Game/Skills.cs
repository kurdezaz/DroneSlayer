using DroneSlayer.PlayerEntity;
using DroneSlayer.PlayerEntity.PlayerSkill;
using DroneSlayer.UI.Menu.Buttons.SkillButtons;
using DroneSlayer.UI.Menu.Descriptions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;

namespace DroneSlayer.Game
{
    public class Skills : MonoBehaviour
    {
        [SerializeField] private Button _upgradeButton;
        [SerializeField] private Button _resetSkillsButton;
        [SerializeField] private SDamageButton _sDamageButton;
        [SerializeField] private SReloadSpeedButton _sReloadSpeedButton;
        [SerializeField] private SCapacityButton _sCapacityButton;
        [SerializeField] private SMoveSpeedButton _sMoveSpeedButton;
        [SerializeField] private SLeadershipButton _sLeadershipButton;
        [SerializeField] private STradeButton _sTradeButton;
        [SerializeField] private NameStats _nameStats;
        [SerializeField] private DescriptionStats _descriptionStats;

        [SerializeField] private PlayerSkills _playerSkills;
        [SerializeField] private Player _player;

        [SerializeField] private AudioSource _soundChoosePerk;
        [SerializeField] private AudioSource _soundUpgrade;

        private Stats _stats;

        private TextMeshProUGUI _textNameStats;
        private TextMeshProUGUI _textDescriptionStats;

        private void OnEnable()
        {
            Init();

            _sDamageButton.onClick.AddListener(OnSDamageButtonClick);
            _sReloadSpeedButton.onClick.AddListener(OnSReloadSpeedButtonClick);
            _sCapacityButton.onClick.AddListener(OnSCapacityButtonClick);
            _sMoveSpeedButton.onClick.AddListener(OnSMoveSpeedButtonClick);
            _sLeadershipButton.onClick.AddListener(OnSLeadershipButtonClick);
            _sTradeButton.onClick.AddListener(OnSTradeButtonClick);
            _upgradeButton.onClick.AddListener(OnUpgradeButtonClick);
            _resetSkillsButton.onClick.AddListener(OnResetButtonClick);
        }

        private void OnDisable()
        {
            _sDamageButton.onClick.RemoveListener(OnSDamageButtonClick);
            _sReloadSpeedButton.onClick.RemoveListener(OnSReloadSpeedButtonClick);
            _sCapacityButton.onClick.RemoveListener(OnSCapacityButtonClick);
            _sMoveSpeedButton.onClick.RemoveListener(OnSMoveSpeedButtonClick);
            _sLeadershipButton.onClick.RemoveListener(OnSLeadershipButtonClick);
            _sTradeButton.onClick.RemoveListener(OnSTradeButtonClick);
            _upgradeButton.onClick.RemoveListener(OnUpgradeButtonClick);
            _resetSkillsButton.onClick.RemoveListener(OnResetButtonClick);
        }

        private void Awake()
        {
            _textNameStats = _nameStats.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            _textDescriptionStats = _descriptionStats.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        }

        private void Init()
        {
            _textNameStats.text = " ";
            _textDescriptionStats.text = " ";
        }

        private void OnUpgradeButtonClick()
        {
            if (_player.CurrentSkillPoints > 0)
            {
                if (_playerSkills.GetSkill(_stats).Level < _playerSkills.MaxLevel)
                {
                    _soundUpgrade.Play();
                    _playerSkills.Upgrade(_stats);
                    _player.UseSkillPoint();
                    _playerSkills.SaveSkills();
                    YandexGame.SaveLocal();
                }
            }
        }

        private void OnResetButtonClick()
        {
            _soundUpgrade.Play();
            _playerSkills.ResetAllSkills();
            _player.ResetSkillPoints();
            _playerSkills.SaveSkills();
        }

        private void OnSDamageButtonClick()
        {
            OnSkillButtonClick(_sDamageButton.StatsTypes, _sDamageButton);
        }

        private void OnSReloadSpeedButtonClick()
        {
            OnSkillButtonClick(_sReloadSpeedButton.StatsTypes, _sReloadSpeedButton);
        }

        private void OnSCapacityButtonClick()
        {
            OnSkillButtonClick(_sCapacityButton.StatsTypes, _sCapacityButton);
        }

        private void OnSMoveSpeedButtonClick()
        {
            OnSkillButtonClick(_sMoveSpeedButton.StatsTypes, _sMoveSpeedButton);
        }

        private void OnSLeadershipButtonClick()
        {
            OnSkillButtonClick(_sLeadershipButton.StatsTypes, _sLeadershipButton);
        }

        private void OnSTradeButtonClick()
        {
            OnSkillButtonClick(_sTradeButton.StatsTypes, _sTradeButton);
        }

        private void OnSkillButtonClick(Stats stats, Button button)
        {
            _soundChoosePerk.Play();
            _stats = stats;
            WriteButtonStats(button);
        }

        private void WriteButtonStats(Button button)
        {
            _textNameStats.text = GetInfoButton(button, 0).text;
            _textDescriptionStats.text = GetInfoButton(button, 1).text;
        }

        private TextMeshProUGUI GetInfoButton(Button button, int nuberChild)
        {
            return button.gameObject.transform.GetChild(nuberChild).GetComponent<TextMeshProUGUI>();
        }
    }
}