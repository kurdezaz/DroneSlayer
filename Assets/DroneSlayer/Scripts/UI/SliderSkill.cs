using DroneSlayer.PlayerEntity.PlayerSkill;
using UnityEngine;
using UnityEngine.UI;

namespace DroneSlayer.UI
{
    public class SliderSkill : BarViewSkills
    {
        [SerializeField] private Slider _sliderSkill;
        [SerializeField] private PlayerSkills _playerSkills;
        [SerializeField] private Stats stats;

        private int _minLevelSkillPoints = 0;

        public override void DisplayValue()
        {
            _sliderSkill.value = _playerSkills.GetSkill(stats).Level;
        }

        public override void Init()
        {
            _sliderSkill.minValue = _minLevelSkillPoints;
            _sliderSkill.maxValue = _playerSkills.MaxLevel;
            _sliderSkill.value = _playerSkills.GetSkill(stats).Level;
        }
    }
}