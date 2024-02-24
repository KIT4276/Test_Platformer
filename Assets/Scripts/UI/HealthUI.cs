using Platformer.Service;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Platformer
{
    public class HealthUI : MonoBehaviour
    {
        [SerializeField]
        private Image _imageCurrent;

        [Inject]
        private Health _health;

        public void Init(Health health)
        {
            _health = health;

            _health.ChangeHealthE += ChangeHealth;
        }

        private void ChangeHealth() => 
            _imageCurrent.fillAmount = _health.CurrentHealth / _health.MaxHealth;
    }
}
