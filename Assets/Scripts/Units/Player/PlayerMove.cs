using Platformer.Service.Input;
using UnityEngine;

namespace Platformer.Units.Player
{
    public class PlayerMove : MonoBehaviour
    {
        private const string GroundTag = "Ground";
        [SerializeField]
        private CharacterController _controller;

        [Space, SerializeField]
        private float _playerSpeed = 2.0f;
        [SerializeField]
        private float _jumpHeight = 1.0f;
        [SerializeField]
        private float _gravityValue = 9.81f;

        private Vector3 _playerVelocity;
        private IInputService _input;
        private Vector3 _move;
        private bool _isTouchGround = true;

        private void Start() =>// Compile the architecture has not yet been created
            _input = DefineInputService();

        void Update()
        {
            if (_controller.isGrounded && _playerVelocity.y < Constants.Epsilon)
                _playerVelocity.y = 0f;
            
            if (_input.Axis.sqrMagnitude > Constants.Epsilon)
            {
                _move = Camera.main.transform.TransformDirection(_input.Axis);
                _move.y = 0;
                _move.Normalize();
            }
            else
                _move = Vector3.zero;

            _controller.Move(_playerSpeed * Time.deltaTime * _move);

            if (_move != Vector3.zero)
                transform.forward = _move;

            if (_input.IsJumpButtonUp() && _isTouchGround)
            {
                _isTouchGround = false;
                _playerVelocity.y += Mathf.Sqrt(_jumpHeight * -3.0f * -_gravityValue);
            }

            _playerVelocity.y += -_gravityValue * Time.deltaTime;
            _controller.Move(_playerVelocity * Time.deltaTime);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag(GroundTag))
                _isTouchGround = true;
        }

        private static IInputService DefineInputService()// Compile the architecture has not yet been created
        {
            if (Application.isEditor)
                return new StandaloneInputService();
            else
                return new MobileInputService();
        }
    }
}
