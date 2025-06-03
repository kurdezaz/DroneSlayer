using DroneSlayer.WeaponEntity;
using UnityEngine.UI;

namespace DroneSlayer.UI.Menu.Buttons.WeaponButtons
{
    public class WM249Button : Button
    {
        private WeaponTypes _weaponTypes = WeaponTypes.M249;

        public WeaponTypes WeaponTypes => _weaponTypes;
    }
}