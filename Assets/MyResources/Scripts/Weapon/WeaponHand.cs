using UnityEngine;
using YG;

public class WeaponHand : MonoBehaviour
{
    [SerializeField] private Weapons _weapons;

    private void OnEnable()
    {
        _weapons.WeaponChanged += ChangeWeapon;
        ChangeWeapon(_weapons.WeaponType);
    }

    private void OnDisable()
    {
        _weapons.WeaponChanged -= ChangeWeapon;
    }

    public void SaveWeapons()
    {
        SetActiveAllWeapons();

        Weapon[] weapons = ChooseAllWeapons();

        for(int i = 0; i< weapons.Length; i++)
        {
            YandexGame.savesData.isSold[i] = weapons[i].IsSold;
        }

        SetInactiveAllWeapons();
    }

    public void LoadWeapons()
    {
        SetActiveAllWeapons();

        Weapon[] weapons = ChooseAllWeapons();

        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SaveIsSold(YandexGame.savesData.isSold[i]);
        }

        SetInactiveAllWeapons();
    }

    public void ChangeWeapon(WeaponTypes weaponTypes)
    {
        SetActiveAllWeapons();

        foreach (Weapon weapon in ChooseAllWeapons())
        {
            if (weapon.WeaponType == weaponTypes)
            {
                weapon.gameObject.SetActive(true);
                weapon.EquipWeapon();
            }
            else
            {
                weapon.UnequipWeapon();
                weapon.gameObject.SetActive(false);
            }
        }
    }

    public Weapon GetWeapon(WeaponTypes weaponTypes)
    {
        SetActiveAllWeapons();

        foreach (Weapon weapon in ChooseAllWeapons())
        {
            if (weapon.WeaponType == weaponTypes)
            {
                return weapon;
            }
        }

        SetInactiveAllWeapons();
        return null;
    }

    public void SetActiveAllWeapons()
    {
        foreach (Transform child in this.transform)
        {
            child.gameObject.SetActive(true);
        }
    }

    public void SetInactiveAllWeapons()
    {
        foreach (Transform child in this.transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    private Weapon[] ChooseAllWeapons()
    {
        return gameObject.transform.GetComponentsInChildren<Weapon>();
    }
}
