using System;
using UnityEngine;
using YG;

public class Player : MonoBehaviour
{
    private float _constantExpirience = 0;
    private float _modifiedExpirience = 50f;

    public int PlayerLevel { get; private set; } = 1;
    public float Expirience { get; private set; } = 0;
    public float MinExpirience { get; private set; } = 0;
    public float MaxExpirience { get; private set; } = 100f;
    public int CurrentSkillPoints { get; private set; } = 1;

    public int MaxSkillPoints => PlayerLevel;

    public event Action ExpChanged;
    public event Action LvlChanged;
    public event Action SkillPointsChanged;

    private void Awake()
    {
        MaxExpirience = PlayerLevel * _modifiedExpirience + _constantExpirience;
    }

    public void LoadPlayerLevel()
    {
        PlayerLevel = YandexGame.savesData.playerLevel;
        CurrentSkillPoints = YandexGame.savesData.skillPoints;
        LvlChanged?.Invoke();
    }

    public void LoadPlayerExpirience()
    {
        MaxExpCalculate(PlayerLevel);
        Expirience = YandexGame.savesData.playerExpirience;
    }

    public void GainExpirience(float expirience)
    {
        Expirience += expirience;
        YandexGame.savesData.playerExpirience = Expirience;

        if (Expirience >= MaxExpirience)
        {
            PlayerLevel++;
            YandexGame.savesData.playerLevel = PlayerLevel;
            CurrentSkillPoints++;
            YandexGame.savesData.skillPoints = CurrentSkillPoints;
            MaxExpirience = MaxExpCalculate(PlayerLevel);
            Expirience = 0;
            YandexGame.savesData.playerExpirience = Expirience;
            LvlChanged?.Invoke();
        }

        ExpChanged?.Invoke();
    }

    public void UseSkillPoint()
    {
        if (CurrentSkillPoints > 0)
        {
            CurrentSkillPoints--;
            YandexGame.savesData.skillPoints = CurrentSkillPoints;
            SkillPointsChanged?.Invoke();
        }
    }

    public void ResetSkillPoints()
    {
        CurrentSkillPoints = MaxSkillPoints;
        YandexGame.savesData.skillPoints = CurrentSkillPoints;
        SkillPointsChanged?.Invoke();
    }

    private float MaxExpCalculate(int playerLevel)
    {
        return MaxExpirience = playerLevel * _modifiedExpirience + _constantExpirience;
    }
}
