using Platformer.States;
using System;

namespace Platformer.Service
{
    public class Death : IService
    {
        private readonly Health _health;
        private readonly StateMachine _stateMachine;

        public event Action OnDeadE;

        public Death(Health health, StateMachine stateMachine)
        {
            _health = health;
            _stateMachine = stateMachine;
            _health.ChangeHealthE += CheckHealth;
        }

        public void EndDeath()
        {
            _health.Restart();
            _stateMachine.Enter<BootstrapState>();
        }

        private void CheckHealth()
        {
            if (_health.CurrentHealth <= 0)
                OnDead();
        }

        public void OnDead() => 
            OnDeadE?.Invoke();
    }
}
