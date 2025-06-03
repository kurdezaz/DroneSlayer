using DroneSlayer.PlayerEntity.PlayerSkill;
using UnityEngine.UI;

namespace DroneSlayer.UI.Menu.Buttons.SkillButtons
{
    public class STradeButton : Button
    {
        private Stats _statsTypes = Stats.Trade;

        public Stats StatsTypes => _statsTypes;
    }
}