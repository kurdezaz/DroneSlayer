using System;
using DroneSlayer.PlayerEntity.PlayerSkill;
using UnityEngine;
using UnityEngine.UI;

namespace DroneSlayer.UI.Menu.Buttons.SkillButtons
{
    public class SkillStatButtonHandler : MonoBehaviour
    {
        [SerializeField] private Stats _type;
        [SerializeField] private Button _button;

        public event Action<Stats, Button> Clicked;

        private void OnEnable() =>
            _button.onClick.AddListener(SendEvent);

        private void OnDisable() =>
            _button.onClick.RemoveListener(SendEvent);

        private void SendEvent() =>
            Clicked?.Invoke(_type, _button);
    }
}