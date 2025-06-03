using DroneSlayer.PlayerEntity.PlayerSkill;
using UnityEngine.UI;

namespace DroneSlayer.UI.Menu.Buttons.SkillButtons
{
    public class SLeadershipButton : Button
    {
        private Stats _statsTypes = Stats.Leadership;

        public Stats StatsTypes => _statsTypes;
    }
}