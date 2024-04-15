using Platformer.Service;
using Platformer.Service.Input;
using System;
using UnityEngine;

namespace Platformer.Player
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] private CharacterController _controller;
        [Space]
        [SerializeField] private float _startSpeed = 2f;
        [SerializeField] private float _jumpHeight = 1.0f;
        [SerializeField] private float _gravityValue = 9.81f;
        [SerializeField] private float _minY = 0;

        private float _playerSpeed;
        private Vector3 _playerVelocity;
        private Death _deth;
        private IInputService _input;
        private Vector3 _move;
        private bool _isTouchGround = true;

        private const string GroundTag = "Ground";

        public void Init(IInputService input, Death deth)
        {
            _deth = deth;
            _input = input;
            _playerSpeed = _startSpeed;
        }

        public void SlowDown(float value)
        {
            _playerSpeed -= _playerSpeed * value / 100;

            if (_playerSpeed < 0)
                _playerSpeed = 0;
        }

        public void ReturnSpeed()
        {
            _playerSpeed = _startSpeed;
        }

        private void Update()
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
                _deth.OnDead();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag(GroundTag))
                _isTouchGround = true;
        }
    }
}
