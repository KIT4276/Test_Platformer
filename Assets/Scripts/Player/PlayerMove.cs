using Platformer.Service.Input;
using UnityEngine;

namespace Platformer.Player
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
        [SerializeField]
        private float _minY = 0;

        private Vector3 _playerVelocity;
        private Health _health;
        private IInputService _input;
        private Vector3 _move;
        private bool _isTouchGround = true;

        public void Init(IInputService input, Health health)
        {
            _health = health;
            _input = input;
        }

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

            if (transform.position.y <= _minY)
                _health.Fall();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag(GroundTag))
                _isTouchGround = true;
        }

    }
}
