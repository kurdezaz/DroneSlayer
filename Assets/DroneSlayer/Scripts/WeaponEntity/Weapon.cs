using UnityEngine;
using DroneSlayer.PlayerEntity.PlayerSkill;

namespace DroneSlayer.WeaponEntity
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private WeaponTypes _weaponTypes;
        [SerializeField] private float _weaponPrice;
        [SerializeField] private bool _isSold = false;
        [SerializeField] private bool _isEquiped;

        private float _baseWeaponPrice;

        public WeaponTypes WeaponType => _weaponTypes;
        public float WeaponPrice => _weaponPrice;
        public bool IsSold => _isSold;
        public bool IsEquiped => _isEquiped;

        private void Awake()
        {
            _baseWeaponPrice = _weaponPrice;
        }

        public void BuyWeapon()
        {
            _isSold = true;
        }

        public void EquipWeapon()
        {
            _isEquiped = true;
        }

        public void UnequipWeapon()
        {
            _isEquiped = false;
        }

        public void ChangePrice(DataSkill skill)
        {
            _weaponPrice = _baseWeaponPrice;
            _weaponPrice *= skill.Values[skill.Level];
        }

        public void SaveIsSold(bool isSold)
        {
            _isSold = isSold;
        }
    }
}