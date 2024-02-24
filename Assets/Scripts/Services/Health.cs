using System;

namespace Platformer.Service
{
    public class Health  : IService
    {
        public float MaxHealth { get; private set; }
        public float CurrentHealth { get; private set; }

        public event Action ChangeHealthE;

        public Health()
        {
            MaxHealth = 100; // перенести в статы
            CurrentHealth = MaxHealth;
            ChangeHealthE?.Invoke();
        }

        public void SetDamage(float damage)
        {
            CurrentHealth -= damage;
            ChangeHealthE?.Invoke();
        }
    }
}
