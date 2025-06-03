using DroneSlayer.WeaponEntity;
using UnityEngine.UI;

namespace DroneSlayer.UI.Menu.Buttons.WeaponButtons
{
    public class WAK74Button : Button
    {
        private WeaponTypes _weaponTypes = WeaponTypes.AK74;

        public WeaponTypes WeaponTypes => _weaponTypes;
    }
}