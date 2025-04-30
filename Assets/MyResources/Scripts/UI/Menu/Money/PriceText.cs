using TMPro;
using UnityEngine;

public class PriceText : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private Weapons _weapons;
    [SerializeField] private TextMeshProUGUI _weaponText;
    [SerializeField] private TextMeshProUGUI _soldText;
    [SerializeField] private TextMeshProUGUI _equipedText;

    private void OnEnable()
    {
        WritePriceWeaponText();
        WriteSoldWeaponText();
        WriteEquipedWeaponText();
        _wallet.MoneyChanged += WriteSoldWeaponText;
        _weapons.WeaponEquiped += WriteEquipedWeaponText;
    }

    private void OnDisable()
    {
        _wallet.MoneyChanged -= WriteSoldWeaponText;
        _weapons.WeaponEquiped -= WriteEquipedWeaponText;
    }

    private void WritePriceWeaponText()
    {
        _weaponText.text = _weapon.WeaponPrice.ToString();
    }

    private void WriteSoldWeaponText()
    {
        if (_weapon.IsSold == true)
        {
            _weaponText.text = _soldText.text;
        }
    }

    private void WriteEquipedWeaponText()
    {
        if (_weapon.IsSold == true && _weapon.IsEquiped == true)
        {
            _weaponText.text = _equipedText.text;
        }
        else if (_weapon.IsSold == true)
        {
            _weaponText.text = _soldText.text;
        }
    }
}
