using Platformer.Service;
using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    [SerializeField]
    private float _maxHealth = 100;
    
    public override void InstallBindings()
    {
        InstallHealth();
        InstallDeath();
    }

    private void InstallDeath() => 
        Container.BindInterfacesAndSelfTo<Death>().AsSingle().NonLazy();

    private void InstallHealth() => 
        Container.BindInterfacesAndSelfTo<Health>().AsSingle().WithArguments(_maxHealth).NonLazy();
}