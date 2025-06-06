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
        [SerializeField] private SkillStatButtonHandler _sDamageButton;
        [SerializeField] private SkillStatButtonHandler _sReloadSpeedButton;
        [SerializeField] private SkillStatButtonHandler _sCapacityButton;
        [SerializeField] private SkillStatButtonHandler _sMoveSpeedButton;
        [SerializeField] private SkillStatButtonHandler _sLeadershipButton;
        [SerializeField] private SkillStatButtonHandler _sTradeButton;
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

            _sDamageButton.Clicked += OnSkillButtonClick;
            _sReloadSpeedButton.Clicked += OnSkillButtonClick;
            _sCapacityButton.Clicked += OnSkillButtonClick;
            _sMoveSpeedButton.Clicked += OnSkillButtonClick;
            _sLeadershipButton.Clicked += OnSkillButtonClick;
            _sTradeButton.Clicked += OnSkillButtonClick;

            _upgradeButton.onClick.AddListener(OnUpgradeButtonClick);
            _resetSkillsButton.onClick.AddListener(OnResetButtonClick);
        }

        private void OnDisable()
        {
            _sDamageButton.Clicked -= OnSkillButtonClick;
            _sReloadSpeedButton.Clicked -= OnSkillButtonClick;
            _sCapacityButton.Clicked -= OnSkillButtonClick;
            _sMoveSpeedButton.Clicked -= OnSkillButtonClick;
            _sLeadershipButton.Clicked -= OnSkillButtonClick;
            _sTradeButton.Clicked -= OnSkillButtonClick;

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

        private void OnSkillButtonClick(Stats stats,Button button)
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