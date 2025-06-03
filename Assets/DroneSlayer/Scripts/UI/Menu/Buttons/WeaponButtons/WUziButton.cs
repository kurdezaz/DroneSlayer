using DroneSlayer.WeaponEntity;
using UnityEngine.UI;

namespace DroneSlayer.UI.Menu.Buttons.WeaponButtons
{
    public class WUziButton : Button
    {
        private WeaponTypes _weaponTypes = WeaponTypes.Uzi;

        public WeaponTypes WeaponTypes => _weaponTypes;
    }
}