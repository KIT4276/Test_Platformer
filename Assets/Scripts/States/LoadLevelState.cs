using Platformer.Factories;
using Platformer.Logic;
using Platformer.Service.Input;
using Platformer.Triggers;
using System;
using UnityEngine;

namespace Platformer.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private const string InitialPointTag = "InitialPoint";
        private const string StartTag = "StartTrigger";
        private const string FinTag = "FinishTrigger";

        private readonly StateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _curtain;
        private readonly GameFactory _gameFactory;
        private readonly IInputService _input;
        private GameObject _playerObj;

        public LoadLevelState(StateMachine stateMachine, SceneLoader sceneLoader, 
            LoadingCurtain curtain, GameFactory gameFactory, IInputService input)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _curtain = curtain;
            _gameFactory = gameFactory;
            _input = input;
        }

        public void Enter(string sceneName)
        {
            _curtain.Show();
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit() => 
            _curtain.Hide();

        private void OnLoaded()
        {
            InitGameWorld();

            _stateMachine.Enter<GameLoopState>();
        }

        private void InitGameWorld()
        {
            _playerObj = InitPlayer();
            InitHud(_playerObj);

            CameraFollow(_playerObj);
        }

        private void InitHud(GameObject playerObj)
        {
            var start = GameObject.FindWithTag(StartTag).GetComponent<StartTrigger>();
            var fin = GameObject.FindWithTag(FinTag).GetComponent<FinishTrigger>();

            _gameFactory.CreateHud(start, fin);
        }

        private GameObject InitPlayer() =>
            _gameFactory.CreatePlayerAt(GameObject.FindWithTag(InitialPointTag), _input);

        private void CameraFollow(GameObject player) =>
        Camera.main.GetComponent<CameraFollow>().Follow(player.transform);
    }
}
