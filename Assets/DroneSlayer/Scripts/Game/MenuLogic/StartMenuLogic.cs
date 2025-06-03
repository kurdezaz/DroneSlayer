using DroneSlayer.UI.Menu;
using UnityEngine;
using UnityEngine.UI;

namespace DroneSlayer.Game.MenuLogic
{
    public class StartMenuLogic : MonoBehaviour
    {
        [SerializeField] private Game _game;

        [SerializeField] private MainMenu _mainMenu;
        [SerializeField] private InGameInterface _inGameInterface;

        [SerializeField] private Button _startButton;

        private void OnEnable()
        {
            _startButton.onClick.AddListener(OnStartButtonClick);
        }

        private void OnDisable()
        {
            _startButton.onClick.RemoveListener(OnStartButtonClick);
        }

        private void Awake()
        {
            _mainMenu.Open();
            _game.PauseGame();
        }

        private void OnStartButtonClick()
        {
            _game.PlaySoundOnButton();
            _game.EnableStartCheck();
            _mainMenu.Close();
            _inGameInterface.Open();
            _game.StartGame();
        }
    }
}