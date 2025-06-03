using System;
using UnityEngine;
using YG;

namespace DroneSlayer.PlayerEntity
{
    public class PlayerScore : MonoBehaviour
    {
        private long _score;

        public event Action ScoreChanged;

        public long Score => _score;

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
}