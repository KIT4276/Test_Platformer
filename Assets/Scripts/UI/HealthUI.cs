using System;
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

        //public void SetValue(float current, float max) =>
        //    ImageCurrent.fillAmount = current / max;

        private void Start()
        {
            _health.ChangeHealthE += ChangeHealth;
        }

        private void ChangeHealth() => 
            _imageCurrent.fillAmount = _health.CurrentHealth / _health.MaxHealth;
    }
}
