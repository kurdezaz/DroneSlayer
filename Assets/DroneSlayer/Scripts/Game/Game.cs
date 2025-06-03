using UnityEngine;
using YG;

namespace DroneSlayer.Game
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private AudioSource _soundButton;
        [SerializeField] private AudioSource _backgroundMusic;

        private bool _isGameStarted = false;

        private void OnEnable()
        {
            YandexGame.onVisibilityWindowGame += OnVisibilityWindowGame;
        }

        private void OnDisable()
        {
            YandexGame.onVisibilityWindowGame -= OnVisibilityWindowGame;
        }

        public void PlaySoundOnButton()
        {
            _soundButton.Play();
        }

        public void EnableStartCheck()
        {
            _isGameStarted = true;
        }

        public void DisableStartCheck()
        {
            _isGameStarted = false;
        }

        public void StartGame()
        {
            Time.timeScale = 1;
        }

        public void PauseGame()
        {
            Time.timeScale = 0;
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
    }
}