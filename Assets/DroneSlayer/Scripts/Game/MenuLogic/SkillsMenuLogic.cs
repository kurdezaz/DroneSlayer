using DroneSlayer.UI.Menu;
using UnityEngine;
using UnityEngine.UI;
using YG;

namespace DroneSlayer.Game.MenuLogic
{
    public class SkillsMenuLogic : MonoBehaviour
    {
        [SerializeField] private Game _game;

        [SerializeField] private SkillsMenu _skillsMenu;
        [SerializeField] private InGameInterface _inGameInterface;

        [SerializeField] private Button _skillsMenuButton;
        [SerializeField] private Button _backButtonSkillsMenu;

        private void OnEnable()
        {
            _skillsMenuButton.onClick.AddListener(OnSkillsButtonClick);
            _backButtonSkillsMenu.onClick.AddListener(OnBackButtonSkillsClick);
        }

        private void OnDisable()
        {
            _skillsMenuButton.onClick.RemoveListener(OnSkillsButtonClick);
            _backButtonSkillsMenu.onClick.RemoveListener(OnBackButtonSkillsClick);
        }

        private void OnSkillsButtonClick()
        {
            _game.PlaySoundOnButton();
            _game.DisableStartCheck();
            _inGameInterface.Close();
            _skillsMenu.Open();
            _game.PauseGame();
            YandexGame.FullscreenShow();
        }

        private void OnBackButtonSkillsClick()
        {
            _game.PlaySoundOnButton();
            _game.EnableStartCheck();
            _inGameInterface.Open();
            _skillsMenu.Close();
            _game.StartGame();
        }
    }
}