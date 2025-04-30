using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private PlayerSkills _playerSkills;

    private Rigidbody _rigidbody;

    private Vector3 _horizontalVector;
    private float _maxRunSpeed = 5f;
    private float _baseRunSpeed = 1f;
    private float _runSpeed = 2f;
    private float _maxDistance = 4.5f;

    private void OnEnable()
    {
        _playerSkills.MoveSpeedChanged += ChangeSpeed;
    }

    private void OnDisable()
    {
        _playerSkills.MoveSpeedChanged -= ChangeSpeed;
    }

    private void Awake()
    {
        _baseRunSpeed = _runSpeed;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _horizontalVector.Set(0f, 0f, _playerInput.PlayerMovement);
        _horizontalVector.Normalize();

        if (Mathf.Abs(_rigidbody.velocity.z) < _maxRunSpeed)
        {
            if (transform.position.z > -_maxDistance && _playerInput.PlayerMovement < 0)
            {
                _rigidbody.MovePosition(_rigidbody.position + _horizontalVector * _runSpeed * Time.deltaTime);
            }
            else if (transform.position.z < _maxDistance && _playerInput.PlayerMovement > 0)
            {
                _rigidbody.MovePosition(_rigidbody.position + _horizontalVector * _runSpeed * Time.deltaTime);
            }
        }
    }

    private void ChangeSpeed(DataSkill skill)
    {
        _runSpeed = _baseRunSpeed;
        _runSpeed *= skill.Values[skill.Level];
    }
}
