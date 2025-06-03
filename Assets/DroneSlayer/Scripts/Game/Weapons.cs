using System;
using DroneSlayer.PlayerEntity;
using DroneSlayer.UI.Menu.Buttons.WeaponButtons;
using DroneSlayer.UI.Menu.Descriptions;
using DroneSlayer.WeaponEntity;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;

namespace DroneSlayer.Game
{
    public class Weapons : MonoBehaviour
    {
        [SerializeField] private WeaponHand _weaponHand;
        [SerializeField] private Wallet _wallet;
        [SerializeField] private Button _buyButton;
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

        public event Action<WeaponTypes> WeaponChanged;

        public event Action WeaponEquiped;

        public WeaponTypes WeaponType => _weaponType;

        private void OnEnable()
        {
            Init();

            _buyButton.onClick.AddListener(OnBuyButtonClick);
            _wM1911Button.onClick.AddListener(OnWM1911ButtonClick);
            _wUziButton.onClick.AddListener(OnWUziButtonClick);
            _wBenneliM4Button.onClick.AddListener(OnWBenneliM4ButtonClick);
            _wAK74Button.onClick.AddListener(OnWAK74ButtonClick);
            _wM249Button.onClick.AddListener(OnWM249ButtonClick);
            _wRPG7Button.onClick.AddListener(OnWRPG7ButtonClick);
        }

        private void OnDisable()
        {
            _buyButton.onClick.RemoveListener(OnBuyButtonClick);
            _wM1911Button.onClick.RemoveListener(OnWM1911ButtonClick);
            _wUziButton.onClick.RemoveListener(OnWUziButtonClick);
            _wBenneliM4Button.onClick.RemoveListener(OnWBenneliM4ButtonClick);
            _wAK74Button.onClick.RemoveListener(OnWAK74ButtonClick);
            _wM249Button.onClick.RemoveListener(OnWM249ButtonClick);
            _wRPG7Button.onClick.RemoveListener(OnWRPG7ButtonClick);
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
            _textDescriptionWeaponType.text = " ";
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
            OnWeaponButtonClick(_wM1911Button.WeaponTypes, _wM1911Button);
        }

        private void OnWUziButtonClick()
        {
            OnWeaponButtonClick(_wUziButton.WeaponTypes, _wUziButton);
        }

        private void OnWBenneliM4ButtonClick()
        {
            OnWeaponButtonClick(_wBenneliM4Button.WeaponTypes, _wBenneliM4Button);
        }

        private void OnWAK74ButtonClick()
        {
            OnWeaponButtonClick(_wAK74Button.WeaponTypes, _wAK74Button);
        }

        private void OnWM249ButtonClick()
        {
            OnWeaponButtonClick(_wM249Button.WeaponTypes, _wM249Button);
        }

        private void OnWRPG7ButtonClick()
        {
            OnWeaponButtonClick(_wRPG7Button.WeaponTypes, _wRPG7Button);
        }

        private void SaveWeaponTypes()
        {
            YandexGame.savesData.weaponTypes = _weaponType;
        }

        private void OnWeaponButtonClick(WeaponTypes weaponTypes, Button button)
        {
            _soundEquipWeaponButton.Play();
            _weaponType = weaponTypes;
            WriteButtonStats(button);
        }

        private void WriteButtonStats(Button button)
        {
            _textDescriptionWeaponType.text = GetInfoButton(button, 0).text;
        }

        private TextMeshProUGUI GetInfoButton(Button button, int nuberChild)
        {
            return button.gameObject.transform.GetChild(nuberChild).GetComponent<TextMeshProUGUI>();
        }
    }
}