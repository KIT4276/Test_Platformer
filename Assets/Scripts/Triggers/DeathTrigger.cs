using Platformer.Service;
using Platformer.Triggers;
using Zenject;

public class DeathTrigger : MainGameTrigger
{
    [Inject] private readonly Death _death;

    protected override void TriggerEnter() => 
        _death.OnDead();
}
