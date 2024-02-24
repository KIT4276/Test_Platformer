using Platformer.Factories;
using Platformer.Logic;
using Platformer.Service.Input;
using UnityEngine;
using Zenject;

namespace Platformer.Installers
{
    public class InfrastructureInstaller : MonoInstaller, ICoroutineRunner
    {
        [SerializeField]
        private GameObject _curtainPrefab;
        [SerializeField]
        private GameObject _entryPointPrefab;

        [SerializeField]
        private GameObject _playerPrefab;
        [SerializeField]
        private GameObject _hudPrefab;
        [SerializeField]
        private GameObject _startMenuPrefab;

        private const string Curtain = "Curtain";
        private const string Infrastructure = "Infrastructure";
        private const string EntryPoint = "EntryPoint";

        public override void InstallBindings()
        {
            InstallInputService();

            this.gameObject.SetActive(true);
            Container.BindInterfacesAndSelfTo<ICoroutineRunner>().FromInstance(this).AsSingle();

            InstallSceneLoader();

            BindFactories();
            BindServices();

            BindEntryPoint();
        }

        private void BindEntryPoint()
        {
            Container.BindInterfacesAndSelfTo<EntryPoint>().FromComponentInNewPrefab(_entryPointPrefab).
           WithGameObjectName(EntryPoint).UnderTransformGroup(Infrastructure).AsSingle().NonLazy();
        }

        private void BindServices()
        {
            Container.BindInterfacesAndSelfTo<LoadingCurtain>().FromComponentInNewPrefab(_curtainPrefab).
            WithGameObjectName(Curtain).UnderTransformGroup(Infrastructure).AsSingle().NonLazy();
        }

        private void BindFactories()
        {
            Container.BindInterfacesAndSelfTo<StateFactory>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<GameFactory>().AsSingle().
                WithArguments(_playerPrefab, _hudPrefab, _startMenuPrefab).NonLazy();
        }

        private void InstallSceneLoader() => 
            Container.Bind<SceneLoader>().FromNew().AsSingle().WithArguments(this).NonLazy();

        private void InstallInputService()
        {
            IInputService input = DefineInputService();
            Container.BindInterfacesAndSelfTo<IInputService>().FromInstance(input).AsSingle().NonLazy();
        }

        private static IInputService DefineInputService()
        {
            if (Application.isEditor)
                return new StandaloneInputService();
            else
                return new MobileInputService();
        }
    }
}