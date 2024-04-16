using Platformer.Factories;
using Platformer.Logic;
using Platformer.Service;
using Platformer.Service.Input;
using UnityEngine;
using Zenject;

namespace Platformer.Installers
{
    public class InfrastructureInstaller : MonoInstaller, ICoroutineRunner
    {
        [SerializeField] private GameObject _curtainPrefab;
        [SerializeField] private GameObject _entryPointPrefab;

        private const string Curtain = "_curtain";
        private const string Infrastructure = "Infrastructure";
        private const string EntryPoint = "EntryPoint";

        public override void InstallBindings()
        {
            InstallInputService();

            this.gameObject.SetActive(true);

            InstallCoroutine();
            InstallSceneLoader();
            InstallFactories();
            InstallServices();
            InstallEntryPoint();
        }

        private void InstallCoroutine() =>
            Container.Bind<ICoroutineRunner>()
            .FromInstance(this)
            .AsSingle();

        private void InstallEntryPoint() => 
            Container.Bind<EntryPoint>()
                .FromComponentInNewPrefab(_entryPointPrefab)
                .WithGameObjectName(EntryPoint)
                .UnderTransformGroup(Infrastructure)
                .AsSingle()
                .NonLazy();

        private void InstallServices()
        {
            Container.Bind<LoadingCurtain>()
                .FromComponentInNewPrefab(_curtainPrefab)
                .WithGameObjectName(Curtain)
                .UnderTransformGroup(Infrastructure)
                .AsSingle()
                .NonLazy();

            Container.Bind<Timer>()
                .FromNew()
                .AsSingle()
                .NonLazy();
        }

        private void InstallFactories()
        {
            Container.Bind<StateFactory>()
                .AsSingle()
                .NonLazy();

            Container.Bind<GameFactory>()
                .AsSingle()
                .NonLazy();
        }

        private void InstallSceneLoader() =>
            Container
            .Bind<SceneLoader>()
            .FromNew()
            .AsSingle()
            .WithArguments(this)
            .NonLazy();

        private void InstallInputService() => 
            Container.Bind<IInputService>()
            .FromInstance(DefineInputService())
            .AsSingle()
            .NonLazy();

        private static IInputService DefineInputService()
        {
            if (Application.isEditor)
                return new StandaloneInputService();
            else
                return new MobileInputService();
        }
    }
}