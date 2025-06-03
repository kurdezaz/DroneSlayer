using DroneSlayer.WeaponEntity;
using UnityEngine.UI;

namespace DroneSlayer.UI.Menu.Buttons.WeaponButtons
{
    public class WM1911Button : Button
    {
        private WeaponTypes _weaponTypes = WeaponTypes.M1911;

        public WeaponTypes WeaponTypes => _weaponTypes;
    }
}