using Platformer.Service;
using UnityEngine;
using UnityEngine.UI;

namespace Platformer.UI
{
    public class HealthUI : MonoBehaviour
    {
        [SerializeField] private Image _imageCurrent;

        private Health _health;

        public void Init(Health health)
        {
            _health = health;
            _health.ChangeHealthE += ChangeHealth;
        }

        private void ChangeHealth() =>
            _imageCurrent.fillAmount = _health.CurrentHealth / _health.MaxHealth;

        private void OnDestroy() =>
            _health.ChangeHealthE -= ChangeHealth;
    }
}
