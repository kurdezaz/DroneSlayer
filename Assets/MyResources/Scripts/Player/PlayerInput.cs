using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private DynamicJoystick _dynamicJoystick;

    private const string Horizontal = "Horizontal";

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
