using DroneSlayer.PlayerEntity.PlayerSkill;
using UnityEngine.UI;

namespace DroneSlayer.UI.Menu.Buttons.SkillButtons
{
    public class SCapacityButton : Button
    {
        private Stats _statsTypes = Stats.Capacity;

        public Stats StatsTypes => _statsTypes;
    }
}