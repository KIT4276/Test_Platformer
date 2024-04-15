using System.Collections;
using UnityEngine;

namespace Platformer.Triggers
{
    public class WindPlatformTrigger : Trap
    {
        [SerializeField] private float _windForce = 1;
        [SerializeField] private float _changeDirectionTime = 2;
        [SerializeField] private AudioSource _audio;
        [SerializeField] private float _audioDecreaseStep = 0.1f;

        private bool _isWindStarted;
        private Vector3 _velocity;

        protected override void LaunchTrap()
        {
            _isActive = true;
            StartCoroutine(ChangeDirectionCoroutine());
            _audio.volume = 0.7f;
        }

        protected override void StopTrap()
        {
            _isActive = false;
            StopCoroutine(ChangeDirectionCoroutine());
            StartCoroutine(AudioCoroutine());
        }

        private IEnumerator AudioCoroutine()
        {
            while (_audio.volume > 0)
            {
                _audio.volume -= _audioDecreaseStep;
                yield return null;
            }
        }

        private IEnumerator ChangeDirectionCoroutine()
        {
            if (!_isWindStarted)
            {
                _isWindStarted = true;

                while (_isActive)
                {
                    ChangeDirection();
                    yield return new WaitForSeconds(_changeDirectionTime);
                }
                _isWindStarted = false;
            }
        }

        private void ChangeDirection()
        {
            var random = RandomForce();

            _velocity = new Vector3(random * Time.deltaTime, 0f, (_windForce - random) * Time.deltaTime);
        }

        private float RandomForce() =>
            Random.Range(0, _windForce);

        private void LateUpdate()
        {
            if (_isActive)
                _player.GetComponent<CharacterController>().Move(_velocity);
        }
    }
}
