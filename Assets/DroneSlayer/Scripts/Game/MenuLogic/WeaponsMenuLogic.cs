using DroneSlayer.UI.Menu;
using UnityEngine;
using UnityEngine.UI;
using YG;

namespace DroneSlayer.Game.MenuLogic
{
    public class WeaponsMenuLogic : MonoBehaviour
    {
        [SerializeField] private Game _game;

        [SerializeField] private WeaponsMenu _weaponsMenu;
        [SerializeField] private InGameInterface _inGameInterface;

        [SerializeField] private Button _weaponsMenuButton;
        [SerializeField] private Button _backButtonWeaponsMenu;

        private void OnEnable()
        {
            _weaponsMenuButton.onClick.AddListener(OnWeaponsButtonClick);
            _backButtonWeaponsMenu.onClick.AddListener(OnBackButtonWeaponsClick);
        }

        private void OnDisable()
        {
            _weaponsMenuButton.onClick.RemoveListener(OnWeaponsButtonClick);
            _backButtonWeaponsMenu.onClick.RemoveListener(OnBackButtonWeaponsClick);
        }

        private void OnWeaponsButtonClick()
        {
            _game.PlaySoundOnButton();
            _game.DisableStartCheck();
            _inGameInterface.Close();
            _weaponsMenu.Open();
            _game.PauseGame();
            YandexGame.FullscreenShow();
        }

        private void OnBackButtonWeaponsClick()
        {
            _game.PlaySoundOnButton();
            _game.EnableStartCheck();
            _inGameInterface.Open();
            _weaponsMenu.Close();
            _game.StartGame();
        }
    }
}