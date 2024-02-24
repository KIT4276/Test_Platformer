using UnityEngine;

namespace Platformer.Triggers
{
    public abstract class Trap : MonoBehaviour
    {
        [SerializeField]
        protected Collider _collider;

        protected const string PlayerTag = "Player";

        protected bool _isActive;

        protected GameObject _player;

        protected void Start() => 
            _collider.isTrigger = true;

        protected void OnTriggerEnter(Collider other)
        {
            Debug.Log("Enter to " + this.name);
            if (other.CompareTag(PlayerTag))
            {
                _player = other.gameObject;
                LaunchTrap();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            Debug.Log("Exit from " + this.name);
            if (other.CompareTag(PlayerTag))
                StopTrap();
        }

        protected abstract void StopTrap();
        protected abstract void LaunchTrap();

    }
}
