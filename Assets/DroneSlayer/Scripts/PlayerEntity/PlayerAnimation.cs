using UnityEngine;

namespace DroneSlayer.PlayerEntity
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimation : MonoBehaviour
    {
        private const string Strafe = "Strafe";
        private const string IsAttack = "IsAttack";

        [SerializeField] private PlayerInput _playerInput;

        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {


            if (Mathf.Abs(_playerInput.PlayerMovement) > 0)
            {
                _animator.SetBool(IsAttack, false);
                _animator.SetFloat(Strafe, _playerInput.PlayerMovement);
            }
            else
            {
                _animator.SetBool(IsAttack, true);
                _animator.SetFloat(Strafe, 0);
            }
        }
    }
}
