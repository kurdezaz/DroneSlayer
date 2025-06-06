using System;
using DroneSlayer.WeaponEntity;
using UnityEngine;
using YG;

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

                switch (skill.Names)
                {
                    case Stats.Leadership:
                        LeadershipSkillChanged?.Invoke(skill.Level);
                        break;
                    case Stats.MoveSpeed:
                        MoveSpeedChanged?.Invoke(skill);
                        break;
                    case Stats.Trade:
                        foreach (var weapon in _weapons)
                        {
                            weapon.ChangePrice(skill);
                        }
                        break;
                    case Stats.Damage:
                        DamageChanged?.Invoke();
                        break;
                    case Stats.Capacity:
                        CapacityChanged?.Invoke();
                        break;
                    case Stats.ReloadSpeed:
                        ReloadChanged?.Invoke();
                        break;
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
            switch (_skills[number].Names)
            {
                case Stats.Leadership:
                    LeadershipSkillChanged?.Invoke(_skills[number].Level);
                    break;
                case Stats.MoveSpeed:
                    MoveSpeedChanged?.Invoke(_skills[number]);
                    break;
                case Stats.Trade:
                    foreach (var weapon in _weapons)
                    {
                        weapon.ChangePrice(_skills[number]);
                    }
                    break;
                case Stats.Damage:
                    DamageChanged?.Invoke();
                    break;
                case Stats.Capacity:
                    CapacityChanged?.Invoke();
                    break;
                case Stats.ReloadSpeed:
                    ReloadChanged?.Invoke();
                    break;
            }
        }
    }
}