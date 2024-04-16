using Platformer.Player;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

namespace Platformer.Triggers
{
    public class CatPlatformTrigger : Trap
    {
        [SerializeField] private float _slowdownPercent = 50;
        [SerializeField] private float _speedReturnDelay = 5;
        [SerializeField] private LoadingVignetteCurtain _vignette;
        [SerializeField] private GameObject _cake;

        protected override void LaunchTrap()
        {
            if (!_isActive)
            {
                _cake.SetActive(false);
                _player.GetComponent<PlayerMove>().SlowDown(_slowdownPercent);
                _isActive = true;
                _vignette.ShowVignette();
            }
        }

        protected override void StopTrap()
        {
            if (_isActive)
            {
                StartCoroutine(SpeedReturnCoroutine());
            }
        }

        private IEnumerator SpeedReturnCoroutine()
        {
            yield return new WaitForSeconds(_speedReturnDelay);
            _vignette.HideVignette();
            _player.GetComponent<PlayerMove>().ReturnSpeed();
            _cake.SetActive(true);
            _isActive = false;
        }
    }
}
