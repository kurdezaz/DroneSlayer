using YG;
using UnityEngine;
using UnityEngine.SceneManagement;
using DroneSlayer.PlayerEntity;
using DroneSlayer.Pools;
using DroneSlayer.UI.Menu;
using DroneSlayer.UI.Menu.Buttons;

namespace DroneSlayer.Game
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private MainMenu _mainMenu;
        [SerializeField] private OptionsMenu _optionsMenu;
        [SerializeField] private InGameInterface _inGameInterface;
        [SerializeField] private SkillsMenu _skillsMenu;
        [SerializeField] private WeaponsMenu _weaponsMenu;
        [SerializeField] private WinMenu _winMenu;
        [SerializeField] private WinMenuNoAuth _winMenuNoAuth;
        [SerializeField] private LeaderboardMenu _leaderboardMenu;

        [SerializeField] private StartButton _startButton;
        [SerializeField] private OptionButton _optionButton;
        [SerializeField] private SkillsButton _skillsButton;
        [SerializeField] private WeaponsButton _weaponsButton;
        [SerializeField] private LeaderboardButton _leaderboardButton;
        [SerializeField] private RestartButton _restartButton;
        [SerializeField] private RestartButton _restartButtonWinMenu;
        [SerializeField] private RestartButton _restartButtonWinMenuNoAuth;

        [SerializeField] private BackButton _backButtonOption;
        [SerializeField] private BackButton _backButtonSkills;
        [SerializeField] private BackButton _backButtonWeapons;
        [SerializeField] private BackButton _backButtonLeaderboardMenu;

        [SerializeField] private DronePool _dronePool;
        [SerializeField] private PlayerScore _playerScore;
        [SerializeField] private PlayerHealth _playerHealth;
        [SerializeField] private LeaderboardYG _leaderboardYG;

        [SerializeField] private AudioSource _soundButton;
        [SerializeField] private AudioSource _backgroundMusic;

        private bool _isGameStarted = false;
        private bool _isLBUpdated = false;

        private void OnEnable()
        {
            _startButton.ButtonClicked += OnStartButtonClick;
            _optionButton.ButtonClicked += OnOptionButtonClick;
            _skillsButton.ButtonClicked += OnSkillsButtonClick;
            _weaponsButton.ButtonClicked += OnWeaponsButtonClick;
            _leaderboardButton.ButtonClicked += OnLeaderboardButtonClick;
            _restartButton.ButtonClicked += OnRestartButtonClick;
            _restartButtonWinMenu.ButtonClicked += OnRestartButtonClick;
            _restartButtonWinMenuNoAuth.ButtonClicked += OnRestartButtonClick;

            _backButtonOption.ButtonClicked += OnBackButtonOptionClick;
            _backButtonSkills.ButtonClicked += OnBackButtonSkillsClick;
            _backButtonWeapons.ButtonClicked += OnBackButtonWeaponsClick;
            _backButtonLeaderboardMenu.ButtonClicked += OnBackButtonLeaderboardMenuClick;
            _playerHealth.PlayerDeathReached += ShowWinMenu;
            YandexGame.onVisibilityWindowGame += OnVisibilityWindowGame;
        }

        private void OnDisable()
        {
            _startButton.ButtonClicked -= OnStartButtonClick;
            _optionButton.ButtonClicked -= OnOptionButtonClick;
            _skillsButton.ButtonClicked -= OnSkillsButtonClick;
            _weaponsButton.ButtonClicked -= OnWeaponsButtonClick;
            _leaderboardButton.ButtonClicked -= OnLeaderboardButtonClick;
            _restartButton.ButtonClicked -= OnRestartButtonClick;
            _restartButtonWinMenu.ButtonClicked -= OnRestartButtonClick;
            _restartButtonWinMenuNoAuth.ButtonClicked -= OnRestartButtonClick;

            _backButtonOption.ButtonClicked -= OnBackButtonOptionClick;
            _backButtonSkills.ButtonClicked -= OnBackButtonSkillsClick;
            _backButtonWeapons.ButtonClicked -= OnBackButtonWeaponsClick;
            _backButtonLeaderboardMenu.ButtonClicked -= OnBackButtonLeaderboardMenuClick;
            _playerHealth.PlayerDeathReached -= ShowWinMenu;
            YandexGame.onVisibilityWindowGame -= OnVisibilityWindowGame;
        }

        private void Awake()
        {
            _mainMenu.Open();
            Time.timeScale = 0;
        }

        private void OnStartButtonClick()
        {
            _soundButton.Play();
            _isGameStarted = true;
            _mainMenu.Close();
            _inGameInterface.Open();
            StartGame();
        }

        private void OnOptionButtonClick()
        {
            _soundButton.Play();
            _isGameStarted = false;
            _inGameInterface.Close();
            _optionsMenu.Open();
            PauseGame();
        }

        private void OnSkillsButtonClick()
        {
            _soundButton.Play();
            _isGameStarted = false;
            _inGameInterface.Close();
            _skillsMenu.Open();
            PauseGame();
            YandexGame.FullscreenShow();
        }
        private void OnWeaponsButtonClick()
        {
            _soundButton.Play();
            _isGameStarted = false;
            _inGameInterface.Close();
            _weaponsMenu.Open();
            PauseGame();
            YandexGame.FullscreenShow();
        }

        private void OnLeaderboardButtonClick()
        {
            _soundButton.Play();
            _isGameStarted = false;
            _inGameInterface.Close();
            _leaderboardMenu.Open();
            _leaderboardYG.UpdateLB();

            if (_isLBUpdated == false)
            {
                _isLBUpdated = true;
            }

            PauseGame();
            YandexGame.FullscreenShow();
        }

        private void OnRestartButtonClick()
        {
            YandexGame.NewLeaderboardScores("DroneSlayerLeaderBoard", _playerScore.Score);
            YandexGame.ResetSaveProgress();
            YandexGame.SaveProgress();
            YandexGame.SaveLocal();
            SceneManager.LoadScene("SampleScene");
        }

        private void OnBackButtonOptionClick()
        {
            _soundButton.Play();
            _isGameStarted = true;
            _inGameInterface.Open();
            _optionsMenu.Close();
            StartGame();
        }

        private void OnBackButtonSkillsClick()
        {
            _soundButton.Play();
            _isGameStarted = true;
            _inGameInterface.Open();
            _skillsMenu.Close();
            StartGame();
        }

        private void OnBackButtonWeaponsClick()
        {
            _soundButton.Play();
            _isGameStarted = true;
            _inGameInterface.Open();
            _weaponsMenu.Close();
            StartGame();
        }

        private void OnBackButtonLeaderboardMenuClick()
        {
            _soundButton.Play();
            _isGameStarted = true;
            _inGameInterface.Open();
            _leaderboardMenu.Close();
            StartGame();
        }

        private void ShowWinMenu()
        {
            if (YandexGame.auth)
            {
                YandexGame.NewLeaderboardScores("DroneSlayerLeaderBoard", _playerScore.Score);
                _isGameStarted = false;
                _winMenu.Open();
                PauseGame();
            }
            else
            {
                _isGameStarted = false;
                _winMenuNoAuth.Open();
                PauseGame();
            }

        }

        private void OnVisibilityWindowGame(bool visible)
        {
            if (visible && _isGameStarted)
            {
                StartGame();
            }
            else
            {
                PauseGame();
                _backgroundMusic.Pause();
            }

            if (visible && _backgroundMusic.isPlaying == false)
            {
                _backgroundMusic.UnPause();
            }
        }

        private void StartGame()
        {
            Time.timeScale = 1;
        }

        private void PauseGame()
        {
            Time.timeScale = 0;
        }
    }
}