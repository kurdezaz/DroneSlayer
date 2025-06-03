using DroneSlayer.UI.Menu;
using UnityEngine;
using UnityEngine.UI;
using YG;

namespace DroneSlayer.Game.MenuLogic
{
    public class LeaderboardMenuLogic : MonoBehaviour
    {
        [SerializeField] private Game _game;

        [SerializeField] private LeaderboardMenu _leaderboardMenu;
        [SerializeField] private InGameInterface _inGameInterface;

        [SerializeField] private Button _leaderboardMenuButton;
        [SerializeField] private Button _backButtonLeaderboardMenu;

        [SerializeField] private LeaderboardYG _leaderboardYG;

        private void OnEnable()
        {
            _leaderboardMenuButton.onClick.AddListener(OnLeaderboardButtonClick);
            _backButtonLeaderboardMenu.onClick.AddListener(OnBackButtonLeaderboardClick);
        }

        private void OnDisable()
        {
            _leaderboardMenuButton.onClick.RemoveListener(OnLeaderboardButtonClick);
            _backButtonLeaderboardMenu.onClick.RemoveListener(OnBackButtonLeaderboardClick);
        }

        private void OnLeaderboardButtonClick()
        {
            _game.PlaySoundOnButton();
            _game.DisableStartCheck();
            _inGameInterface.Close();
            _leaderboardMenu.Open();
            _leaderboardYG.UpdateLB();
            _game.PauseGame();
            YandexGame.FullscreenShow();
        }

        private void OnBackButtonLeaderboardClick()
        {
            _game.PlaySoundOnButton();
            _game.EnableStartCheck();
            _inGameInterface.Open();
            _leaderboardMenu.Close();
            _game.StartGame();
        }
    }
}