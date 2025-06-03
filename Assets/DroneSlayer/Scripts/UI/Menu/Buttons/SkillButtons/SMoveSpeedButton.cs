using DroneSlayer.PlayerEntity.PlayerSkill;
using UnityEngine.UI;

namespace DroneSlayer.UI.Menu.Buttons.SkillButtons
{
    public class SMoveSpeedButton : Button
    {
        private Stats _statsTypes = Stats.MoveSpeed;

        public Stats StatsTypes => _statsTypes;
    }
}