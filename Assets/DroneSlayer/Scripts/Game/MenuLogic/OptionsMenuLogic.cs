using DroneSlayer.UI.Menu;
using UnityEngine;
using UnityEngine.UI;

namespace DroneSlayer.Game.MenuLogic
{
    public class OptionsMenuLogic : MonoBehaviour
    {
        [SerializeField] private Game _game;
        [SerializeField] private RestartGameLogic _restartGameLogic;

        [SerializeField] private OptionsMenu _optionsMenu;
        [SerializeField] private InGameInterface _inGameInterface;

        [SerializeField] private Button _optionButton;
        [SerializeField] private Button _backButtonOption;
        [SerializeField] private Button _restartButton;

        private void OnEnable()
        {
            _optionButton.onClick.AddListener(OnOptionButtonClick);
            _backButtonOption.onClick.AddListener(OnBackButtonOptionClick);
            _restartButton.onClick.AddListener(_restartGameLogic.OnRestartButtonClick);
        }

        private void OnDisable()
        {
            _optionButton.onClick.RemoveListener(OnOptionButtonClick);
            _backButtonOption.onClick.RemoveListener(OnBackButtonOptionClick);
            _restartButton.onClick.RemoveListener(_restartGameLogic.OnRestartButtonClick);
        }

        private void OnOptionButtonClick()
        {
            _game.PlaySoundOnButton();
            _game.DisableStartCheck();
            _inGameInterface.Close();
            _optionsMenu.Open();
            _game.PauseGame();
        }

        private void OnBackButtonOptionClick()
        {
            _game.PlaySoundOnButton();
            _game.EnableStartCheck();
            _inGameInterface.Open();
            _optionsMenu.Close();
            _game.StartGame();
        }
    }
}