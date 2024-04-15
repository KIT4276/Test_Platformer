using Platformer.States;
using Zenject;

namespace Platformer.Installers
{
    public class StateMachineInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<BootstrapState>()
                .AsSingle()
                .NonLazy();

            Container.Bind<LoadProgressState>()
                .AsSingle()
                .NonLazy();

            Container.Bind<LoadLevelState>()
                .AsSingle()
                .NonLazy();

            Container.Bind<GameLoopState>()
                .AsSingle()
                .NonLazy();

            Container
              .BindInterfacesAndSelfTo<StateMachine>()
              .AsSingle();
        }
    }
}