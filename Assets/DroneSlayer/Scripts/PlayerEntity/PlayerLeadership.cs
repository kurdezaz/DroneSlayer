using DroneSlayer.PlayerEntity.PlayerSkill;
using UnityEngine;

namespace DroneSlayer.PlayerEntity
{
    public class PlayerLeadership : MonoBehaviour
    {
        [SerializeField] private PlayerSkills _playerSkills;
        [SerializeField] private GameObject _playerHelper1;
        [SerializeField] private GameObject _playerHelper2;

        private void OnEnable()
        {
            _playerSkills.LeadershipSkillChanged += ChangeCountHelpers;
        }

        private void OnDisable()
        {
            _playerSkills.LeadershipSkillChanged -= ChangeCountHelpers;
        }

        private void ChangeCountHelpers(int level)
        {
            if (level == 0)
            {
                _playerHelper1.gameObject.SetActive(false);
                _playerHelper2.gameObject.SetActive(false);
            }
            else if (level == 1)
            {
                _playerHelper1.gameObject.SetActive(true);
                _playerHelper2.gameObject.SetActive(false);
            }
            else if (level == 2)
            {
                _playerHelper1.gameObject.SetActive(true);
                _playerHelper2.gameObject.SetActive(true);
            }
        }
    }
}