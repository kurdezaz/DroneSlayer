using DroneSlayer.PlayerEntity;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

namespace DroneSlayer.Game.MenuLogic
{
    public class RestartGameLogic : MonoBehaviour
    {
        [SerializeField] private PlayerScore _playerScore;

        public void OnRestartButtonClick()
        {
            YandexGame.NewLeaderboardScores("DroneSlayerLeaderBoard", _playerScore.Score);
            YandexGame.ResetSaveProgress();
            YandexGame.SaveProgress();
            YandexGame.SaveLocal();
            SceneManager.LoadScene("SampleScene");
        }
    }
}