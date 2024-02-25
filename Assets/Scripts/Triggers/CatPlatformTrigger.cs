using Platformer.Player;
using System.Collections;
using UnityEngine;

namespace Platformer.Triggers
{
    public class CatPlatformTrigger : Trap
    {
        [SerializeField]
        private float _slowdownValue = 1;
        [SerializeField]
        private LoadingVignetteCurtain _vignette;
        [SerializeField]
        private float _speedReturnDelay = 5;

        protected override void LaunchTrap()
        {
            if (!_isActive)
            {
                _player.GetComponent<PlayerMove>().SlowDown(_slowdownValue);
                _isActive = true;
                _vignette.ShowVignette();
            }
        }

        protected override void StopTrap()
        {
            if (_isActive)
            {
                StartCoroutine(SpeedReturnCoroutine());
                _isActive = false;
            }
        }

        private IEnumerator SpeedReturnCoroutine()
        {
            yield return new WaitForSeconds(_speedReturnDelay);
            _vignette.HideVignette();
            _player.GetComponent<PlayerMove>().SlowDown(-_slowdownValue);
        }
    }
}
