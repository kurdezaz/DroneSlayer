using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace DroneSlayer.UI.Menu.Sliders
{
    public class VolumeSlider : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private AudioMixerGroup _audioMixer;
        [SerializeField] private TypeVolumes _typeVolumes;

        private float _coefficient = 20;

        public enum TypeVolumes
        {
            MasterVolume = 0,
            MusicVolume,
            EffectsVolume,
        }

        private void OnEnable()
        {
            _slider.onValueChanged.AddListener(ChangeMasterVolume);
        }

        private void OnDisable()
        {
            _slider.onValueChanged.RemoveListener(ChangeMasterVolume);
        }

        public void ChangeMasterVolume(float volume)
        {
            _audioMixer.audioMixer.SetFloat(_typeVolumes.ToString(), CalculateVolume(volume));
        }

        private float CalculateVolume(float volume)
        {
            return Mathf.Log10(volume) * _coefficient;
        }
    }
}