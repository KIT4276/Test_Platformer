using System;
using UnityEngine;

namespace Platformer.Triggers
{
    public abstract class MainGameTrigger : MonoBehaviour
    {
        protected const string PlayerTag = "Player";
        protected Collider _playersCollider;

        public event Action MainGameTriggerEnteredE;

        protected void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(PlayerTag))
            {
                _playersCollider = other;
                TriggerEnter();
                MainGameTriggerEnteredE?.Invoke();
                gameObject.SetActive(false);
            }
        }

        protected abstract void TriggerEnter();
    }
}
