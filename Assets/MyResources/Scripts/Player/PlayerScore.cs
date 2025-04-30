using System;
using UnityEngine;
using YG;

public class PlayerScore : MonoBehaviour
{
    private long _score;

    public long Score => _score;

    public event Action ScoreChanged;

    public void GainScore(long score)
    {
        _score += score;
        YandexGame.savesData.score = _score;
        YandexGame.NewLeaderboardScores("DroneSlayerLeaderBoard", _score);
        ScoreChanged?.Invoke();
        YandexGame.SaveLocal();
    }

    public void LoadPlayerScore()
    {
        _score = YandexGame.savesData.score;
    }
}
