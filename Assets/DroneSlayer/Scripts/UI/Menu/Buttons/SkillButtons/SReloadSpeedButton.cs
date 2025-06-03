using DroneSlayer.PlayerEntity.PlayerSkill;
using UnityEngine.UI;

namespace DroneSlayer.UI.Menu.Buttons.SkillButtons
{
    public class SReloadSpeedButton : Button
    {
        private Stats _statsTypes = Stats.ReloadSpeed;

        public Stats StatsTypes => _statsTypes;
    }
}