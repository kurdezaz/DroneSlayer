using DroneSlayer.PlayerEntity.PlayerSkill;
using UnityEngine.UI;

namespace DroneSlayer.UI.Menu.Buttons.SkillButtons
{
    public class SDamageButton : Button
    {
        private Stats _statsTypes = Stats.Damage;

        public Stats StatsTypes => _statsTypes;
    }
}