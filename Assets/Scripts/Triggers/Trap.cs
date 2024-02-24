using UnityEngine;

namespace Platformer
{
    public abstract class Trap : MonoBehaviour
    {
        [SerializeField]
        protected Collider _collider;

        protected const string PlayerTag = "Player";

        protected void Start()
        {
            _collider.isTrigger = true;
        }

        protected void OnTriggerEnter(Collider other)
        {
            Debug.Log("Enter to " + this.name);
            if (other.CompareTag(PlayerTag))
                LaunchTrap();
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
