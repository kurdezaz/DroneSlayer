using TMPro;
using YG;
using UnityEngine;

public class Skills : MonoBehaviour
{
    [SerializeField] private UpgradeButton _upgradeButton;
    [SerializeField] private ResetSkillsButton _resetSkillsButton;
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

        _sDamageButton.ButtonClicked += OnSDamageButtonClick;
        _sReloadSpeedButton.ButtonClicked += OnSReloadSpeedButtonClick;
        _sCapacityButton.ButtonClicked += OnSCapacityButtonClick;
        _sMoveSpeedButton.ButtonClicked += OnSMoveSpeedButtonClick;
        _sLeadershipButton.ButtonClicked += OnSLeadershipButtonClick;
        _sTradeButton.ButtonClicked += OnSTradeButtonClick;
        _upgradeButton.ButtonClicked += OnUpgradeButtonClick;
        _resetSkillsButton.ButtonClicked += OnResetButtonClick;
    }

    private void OnDisable()
    {
        _sDamageButton.ButtonClicked -= OnSDamageButtonClick;
        _sReloadSpeedButton.ButtonClicked -= OnSReloadSpeedButtonClick;
        _sCapacityButton.ButtonClicked -= OnSCapacityButtonClick;
        _sMoveSpeedButton.ButtonClicked -= OnSMoveSpeedButtonClick;
        _sLeadershipButton.ButtonClicked -= OnSLeadershipButtonClick;
        _sTradeButton.ButtonClicked -= OnSTradeButtonClick;
        _upgradeButton.ButtonClicked -= OnUpgradeButtonClick;
        _resetSkillsButton.ButtonClicked -= OnResetButtonClick;
    }

    private void Awake()
    {
        _textNameStats = _nameStats.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        _textDescriptionStats = _descriptionStats.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    private void Init()
    {
        _textNameStats.text = "";
        _textDescriptionStats.text = "";
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
        _soundChoosePerk.Play();
        _stats = Stats.Damage;
        WriteButtonStats(_sDamageButton);
    }

    private void OnSReloadSpeedButtonClick()
    {
        _soundChoosePerk.Play();
        _stats = Stats.ReloadSpeed;
        WriteButtonStats(_sReloadSpeedButton);
    }

    private void OnSCapacityButtonClick()
    {
        _soundChoosePerk.Play();
        _stats = Stats.Capacity;
        WriteButtonStats(_sCapacityButton);
    }

    private void OnSMoveSpeedButtonClick()
    {
        _soundChoosePerk.Play();
        _stats = Stats.MoveSpeed;
        WriteButtonStats(_sMoveSpeedButton);
    }

    private void OnSLeadershipButtonClick()
    {
        _soundChoosePerk.Play();
        _stats = Stats.Leadership;
        WriteButtonStats(_sLeadershipButton);
    }

    private void OnSTradeButtonClick()
    {
        _soundChoosePerk.Play();
        _stats = Stats.Trade;
        WriteButtonStats(_sTradeButton);
    }

    private void WriteButtonStats(Buttons buttons)
    {
        _textNameStats.text = GetInfoButton(buttons, 0).text;
        _textDescriptionStats.text = GetInfoButton(buttons, 1).text;
    }

    private TextMeshProUGUI GetInfoButton(Buttons buttons, int nuberChild)
    {
        return buttons.gameObject.transform.GetChild(nuberChild).GetComponent<TextMeshProUGUI>();
    }
}
