using System;
using TMPro;
using UnityEngine;
using YG;

public class Weapons : MonoBehaviour
{
    [SerializeField] private WeaponHand _weaponHand;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private BuyButton _buyButton;
    [SerializeField] private WM1911Button _wM1911Button;
    [SerializeField] private WUziButton _wUziButton;
    [SerializeField] private WBenneliM4Button _wBenneliM4Button;
    [SerializeField] private WAK74Button _wAK74Button;
    [SerializeField] private WM249Button _wM249Button;
    [SerializeField] private WRPG7Button _wRPG7Button;

    [SerializeField] private DescriptionStats _descriptionStats;

    [SerializeField] private AudioSource _soundWeaponButton;
    [SerializeField] private AudioSource _soundEquipWeaponButton;

    private WeaponTypes _weaponType;

    private TextMeshProUGUI _textDescriptionWeaponType;

    public WeaponTypes WeaponType => _weaponType;

    public event Action<WeaponTypes> WeaponChanged;
    public event Action WeaponEquiped;

    private void OnEnable()
    {
        Init();

        _buyButton.ButtonClicked += OnBuyButtonClick;
        _wM1911Button.ButtonClicked += OnWM1911ButtonClick;
        _wUziButton.ButtonClicked += OnWUziButtonClick;
        _wBenneliM4Button.ButtonClicked += OnWBenneliM4ButtonClick;
        _wAK74Button.ButtonClicked += OnWAK74ButtonClick;
        _wM249Button.ButtonClicked += OnWM249ButtonClick;
        _wRPG7Button.ButtonClicked += OnWRPG7ButtonClick;
    }

    private void OnDisable()
    {
        _buyButton.ButtonClicked -= OnBuyButtonClick;
        _wM1911Button.ButtonClicked -= OnWM1911ButtonClick;
        _wUziButton.ButtonClicked -= OnWUziButtonClick;
        _wBenneliM4Button.ButtonClicked -= OnWBenneliM4ButtonClick;
        _wAK74Button.ButtonClicked -= OnWAK74ButtonClick;
        _wM249Button.ButtonClicked -= OnWM249ButtonClick;
        _wRPG7Button.ButtonClicked -= OnWRPG7ButtonClick;
    }

    private void Awake()
    {
        _textDescriptionWeaponType = _descriptionStats.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    public void LoadWeaponTypes()
    {
        _weaponHand.LoadWeapons();
        _weaponType = YandexGame.savesData.weaponTypes;
        WeaponChanged?.Invoke(_weaponType);
        WeaponEquiped?.Invoke();
    }

    private void Init()
    {
        _textDescriptionWeaponType.text = "";
    }

    private void OnBuyButtonClick()
    {
        Weapon weapon = _weaponHand.GetWeapon(_weaponType);

        if (_wallet.Money >= weapon.WeaponPrice && weapon.IsSold == false)
        {
            _soundEquipWeaponButton.Play();
            weapon.BuyWeapon();
            _wallet.SpendMoney(weapon.WeaponPrice);
        }
        else
        {
            _weaponHand.SaveWeapons();
            WeaponChanged?.Invoke(WeaponTypes.M1911);
            _weaponHand.ChangeWeapon(WeaponTypes.M1911);
            WeaponEquiped?.Invoke();
        }
        
        if (weapon.IsSold == true)
        {
            _soundEquipWeaponButton.Play();
            _weaponHand.SaveWeapons();
            WeaponChanged?.Invoke(_weaponType);
            _weaponHand.ChangeWeapon(_weaponType);
            SaveWeaponTypes();
            WeaponEquiped?.Invoke();
        }

        YandexGame.SaveLocal();
    }

    private void OnWM1911ButtonClick()
    {
        _soundWeaponButton.Play();
        _weaponType = WeaponTypes.M1911;
        WriteButtonStats(_wM1911Button);
    }

    private void OnWUziButtonClick()
    {
        _soundWeaponButton.Play();
        _weaponType = WeaponTypes.Uzi;
        WriteButtonStats(_wUziButton);
    }

    private void OnWBenneliM4ButtonClick()
    {
        _soundWeaponButton.Play();
        _weaponType = WeaponTypes.Bennelli_M4;
        WriteButtonStats(_wBenneliM4Button);
    }

    private void OnWAK74ButtonClick()
    {
        _soundWeaponButton.Play();
        _weaponType = WeaponTypes.AK74;
        WriteButtonStats(_wAK74Button);
    }

    private void OnWM249ButtonClick()
    {
        _soundWeaponButton.Play();
        _weaponType = WeaponTypes.M249;
        WriteButtonStats(_wM249Button);
    }

    private void OnWRPG7ButtonClick()
    {
        _soundWeaponButton.Play();
        _weaponType = WeaponTypes.RPG7;
        WriteButtonStats(_wRPG7Button);
    }

    private void SaveWeaponTypes()
    {
        YandexGame.savesData.weaponTypes = _weaponType;
    }

    private void WriteButtonStats(Buttons buttons)
    {
        _textDescriptionWeaponType.text = GetInfoButton(buttons, 0).text;
    }

    private TextMeshProUGUI GetInfoButton(Buttons buttons, int nuberChild)
    {
        return buttons.gameObject.transform.GetChild(nuberChild).GetComponent<TextMeshProUGUI>();
    }
}
