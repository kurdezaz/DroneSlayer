using UnityEngine;
using DroneSlayer.PlayerEntity;

namespace DroneSlayer.UI
{
    public abstract class BarView : MonoBehaviour
    {
        [SerializeField] protected Player _playerExpirience;

        private void OnEnable()
        {
            _playerExpirience.ExpChanged += DisplayValue;
        }

        private void OnDisable()
        {
            _playerExpirience.ExpChanged -= DisplayValue;
        }

        public abstract void DisplayValue();
    }
}