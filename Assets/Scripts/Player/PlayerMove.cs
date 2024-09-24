using Platformer.Service.Input;
using UnityEngine;

namespace Platformer.Player
{
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(PlayerAnimator))]
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] private CharacterController _controller;
        [SerializeField] private PlayerAnimator _playerAnimator;
        [Space]
        [SerializeField] private float _startSpeed = 2f;
        [SerializeField] private float _jumpHeight = 1.0f;
        [SerializeField] private float _gravityValue = 9.81f;

        private float _playerSpeed;
        private Vector3 _playerVelocity;
        private IInputService _input;
        private Vector3 _move;

        public void Init(IInputService input)
        {
            _input = input;
            _playerSpeed = _startSpeed;
        }

        public void SlowDown(float value)
        {
            _playerSpeed -= _playerSpeed * value / 100;

            if (_playerSpeed < 0)
                _playerSpeed = 0;
        }

        public void ReturnSpeed() =>
            _playerSpeed = _startSpeed;

        private void Update()
        {
            Jump();
            Move();
            Gravity();
            Animate();
        }

        private void Move()
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
        }

        private void Animate()
        {
            if (Mathf.Abs(_move.x) > 0 || Mathf.Abs(_move.z) > 0)
                _playerAnimator.PlayMove(true);
            else
                _playerAnimator.PlayMove(false);
        }

        private void Gravity()
        {
            _playerVelocity.y += -_gravityValue * Time.deltaTime;
            _controller.Move(_playerVelocity * Time.deltaTime);
        }

        private void Jump()
        {
            if (_input.IsJumpButtonUp() && _controller.isGrounded)
            {
                _playerVelocity.y += Mathf.Sqrt(_jumpHeight * -3.0f * -_gravityValue);
                _playerAnimator.PlayJump();

            }
        }
    }
}
