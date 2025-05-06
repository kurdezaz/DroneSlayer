using TMPro;
using UnityEngine;
using DroneSlayer.PlayerEntity;

namespace DroneSlayer.UI
{
    public class TextPlayerSkillPoints : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textPlayerSkillPoints;
        [SerializeField] private Player _playerSkillPoints;

        private void OnEnable()
        {
            _playerSkillPoints.SkillPointsChanged += DisplayValue;
            DisplayValue();
        }

        private void OnDisable()
        {
            _playerSkillPoints.SkillPointsChanged -= DisplayValue;
        }

        private void DisplayValue()
        {
            _textPlayerSkillPoints.text = _playerSkillPoints.CurrentSkillPoints.ToString();
        }
    }
}