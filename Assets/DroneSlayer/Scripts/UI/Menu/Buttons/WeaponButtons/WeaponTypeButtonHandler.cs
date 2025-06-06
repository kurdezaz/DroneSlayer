using System;
using DroneSlayer.WeaponEntity;
using UnityEngine;
using UnityEngine.UI;

namespace DroneSlayer.UI.Menu.Buttons.WeaponButtons
{
    public class WeaponTypeButtonHandler : MonoBehaviour
    {
        [SerializeField] private WeaponTypes _type;
        [SerializeField] private Button _button;

        public event Action<WeaponTypes, Button> Clicked;

        private void OnEnable() =>
            _button.onClick.AddListener(SendEvent);

        private void OnDisable() =>
            _button.onClick.RemoveListener(SendEvent);

        private void SendEvent() =>
            Clicked?.Invoke(_type, _button);
    }
}