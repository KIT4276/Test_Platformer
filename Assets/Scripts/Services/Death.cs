using Platformer.Logic;
using Platformer.States;
using System;

namespace Platformer.Service
{
    public class Death : IService
    {
        private readonly Health _health;
        private readonly StateMachine _stateMachine;
        private readonly LoadingCurtain _curtain;

        public event Action OnDeadE;

        public Death(Health health, StateMachine stateMachine, LoadingCurtain curtain)
        {
            _health = health;
            _stateMachine = stateMachine;
            _curtain = curtain;
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
