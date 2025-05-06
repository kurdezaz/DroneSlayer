using System;
using UnityEngine;
using YG;
using DroneSlayer.WeaponEntity;

namespace DroneSlayer.PlayerEntity.PlayerSkill
{
    public class PlayerSkills : MonoBehaviour
    {
        [SerializeField] private DataSkill[] _skills;
        [SerializeField] private Weapon[] _weapons;

        public event Action<int> LeadershipSkillChanged;
        public event Action<DataSkill> MoveSpeedChanged;
        public event Action DamageChanged;
        public event Action CapacityChanged;
        public event Action ReloadChanged;

        private int _maxLevel = 2;

        public int MaxLevel => _maxLevel;

        public void Upgrade(Stats names)
        {
            DataSkill skill = GetSkill(names);

            if (skill.Level < _maxLevel)
            {
                skill.UpgradeLevel();

                if (skill.Names == Stats.Leadership)
                {
                    LeadershipSkillChanged?.Invoke(skill.Level);
                }
                else if (skill.Names == Stats.MoveSpeed)
                {
                    MoveSpeedChanged?.Invoke(skill);
                }
                else if (skill.Names == Stats.Trade)
                {
                    foreach (var weapon in _weapons)
                    {
                        weapon.ChangePrice(skill);
                    }
                }
                else if (skill.Names == Stats.Damage)
                {
                    DamageChanged?.Invoke();
                }
                else if (skill.Names == Stats.Capacity)
                {
                    CapacityChanged?.Invoke();
                }
                else if (skill.Names == Stats.ReloadSpeed)
                {
                    ReloadChanged?.Invoke();
                }
            }
        }

        public void ResetAllSkills()
        {
            for (int i = 0; i < _skills.Length; i++)
            {
                _skills[i].ResetLevel();

                UpdateSkill(i);
            }
        }

        public DataSkill GetSkill(Stats names)
        {
            for (int i = 0; i < _skills.Length; i++)
            {
                if (_skills[i].Names == names)
                {
                    return _skills[i];
                }
            }

            return null;
        }

        public void LoadSkills()
        {
            for (int i = 0; i < _skills.Length; i++)
            {
                _skills[i].LoadLevel(YandexGame.savesData.skills[i]);
                UpdateSkill(i);
            }
        }

        public void SaveSkills()
        {
            for (int i = 0; i < _skills.Length; i++)
            {
                YandexGame.savesData.skills[i] = _skills[i].Level;
            }
        }

        private void UpdateSkill(int number)
        {
            if (_skills[number].Names == Stats.Leadership)
            {
                LeadershipSkillChanged?.Invoke(_skills[number].Level);
            }
            else if (_skills[number].Names == Stats.MoveSpeed)
            {
                MoveSpeedChanged?.Invoke(_skills[number]);
            }
            else if (_skills[number].Names == Stats.Trade)
            {
                foreach (var weapon in _weapons)
                {
                    weapon.ChangePrice(_skills[number]);
                }
            }
            else if (_skills[number].Names == Stats.Damage)
            {
                DamageChanged?.Invoke();
            }
            else if (_skills[number].Names == Stats.Capacity)
            {
                CapacityChanged?.Invoke();
            }
            else if (_skills[number].Names == Stats.ReloadSpeed)
            {
                ReloadChanged?.Invoke();
            }
        }
    }
}