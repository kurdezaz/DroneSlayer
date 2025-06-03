using DroneSlayer.WeaponEntity;
using UnityEngine.UI;

namespace DroneSlayer.UI.Menu.Buttons.WeaponButtons
{
    public class WRPG7Button : Button
    {
        private WeaponTypes _weaponTypes = WeaponTypes.RPG7;

        public WeaponTypes WeaponTypes => _weaponTypes;
    }
}