using DroneSlayer.PlayerEntity;
using DroneSlayer.UI.Menu;
using UnityEngine;
using UnityEngine.UI;
using YG;

namespace DroneSlayer.Game.MenuLogic
{
    public class WinMenuLogic : MonoBehaviour
    {
        [SerializeField] private Game _game;
        [SerializeField] private RestartGameLogic _restartGameLogic;

        [SerializeField] private WinMenu _winMenu;
        [SerializeField] private WinMenuNoAuth _winMenuNoAuth;
        [SerializeField] private InGameInterface _inGameInterface;

        [SerializeField] private Button _restartButtonWinMenu;
        [SerializeField] private Button _restartButtonWinMenuNoAuth;

        [SerializeField] private PlayerHealth _playerHealth;
        [SerializeField] private PlayerScore _playerScore;

        private void OnEnable()
        {
            _restartButtonWinMenu.onClick.AddListener(_restartGameLogic.OnRestartButtonClick);
            _restartButtonWinMenuNoAuth.onClick.AddListener(_restartGameLogic.OnRestartButtonClick);

            _playerHealth.PlayerDeathReached += ShowWinMenu;
        }

        private void OnDisable()
        {
            _restartButtonWinMenu.onClick.RemoveListener(_restartGameLogic.OnRestartButtonClick);
            _restartButtonWinMenuNoAuth.onClick.RemoveListener(_restartGameLogic.OnRestartButtonClick);

            _playerHealth.PlayerDeathReached -= ShowWinMenu;
        }

        private void ShowWinMenu()
        {
            if (YandexGame.auth)
            {
                YandexGame.NewLeaderboardScores("DroneSlayerLeaderBoard", _playerScore.Score);
                _game.DisableStartCheck();
                _winMenu.Open();
                _game.PauseGame();
            }
            else
            {
                _game.DisableStartCheck();
                _winMenuNoAuth.Open();
                _game.PauseGame();
            }
        }
    }
}