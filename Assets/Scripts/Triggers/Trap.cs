using UnityEngine;

namespace Platformer.Triggers
{
    public abstract class Trap : MonoBehaviour
    {
        [SerializeField] protected Collider _collider;

        protected bool _isActive;

        protected GameObject _player;

        protected const string PlayerTag = "Player";

        protected void Start() =>
            _collider.isTrigger = true;

        protected void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(PlayerTag))
            {
                _player = other.gameObject;
                LaunchTrap();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(PlayerTag))
                StopTrap();
        }

        protected abstract void StopTrap();
        protected abstract void LaunchTrap();

    }
}
