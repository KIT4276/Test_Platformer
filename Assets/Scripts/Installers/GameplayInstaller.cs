using Platformer.Service;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        InstallHealth();
        InstallDeath();
    }

    private void InstallDeath() => 
        Container.BindInterfacesAndSelfTo<Death>().AsSingle().NonLazy();

    private void InstallHealth() => 
        Container.BindInterfacesAndSelfTo<Health>().AsSingle().NonLazy();
}