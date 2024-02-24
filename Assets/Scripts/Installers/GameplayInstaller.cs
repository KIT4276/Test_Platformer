using Platformer;
using Platformer.Factories;
using System;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        InstallHealth();
    }

    private void InstallHealth()
    {
        Container.BindInterfacesAndSelfTo<Health>().AsSingle().NonLazy();
    }
}