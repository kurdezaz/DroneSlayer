using DroneSlayer.WeaponEntity;
using UnityEngine.UI;

namespace DroneSlayer.UI.Menu.Buttons.WeaponButtons
{
    public class WBenneliM4Button : Button
    {
        private WeaponTypes _weaponTypes = WeaponTypes.Bennelli_M4;

        public WeaponTypes WeaponTypes => _weaponTypes;
    }
}