using UnityEngine;

namespace DroneSlayer.PlayerEntity
{
    public class PlayerInput : MonoBehaviour
    {
        private const string Horizontal = "Horizontal";

        [SerializeField] private DynamicJoystick _dynamicJoystick;

        public float PlayerMovement { get; private set; }

        private void Awake()
        {
            PlayerMovement = 0;
        }

        private void Update()
        {
            PlayerMovement = Input.GetAxis(Horizontal);

            if (PlayerMovement == 0)
            {
                PlayerMovement = _dynamicJoystick.Horizontal;
            }
        }
    }
}