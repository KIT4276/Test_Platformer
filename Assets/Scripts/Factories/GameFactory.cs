using Platformer.Service;
using Platformer.Service.Input;
using Platformer.Triggers;
using Platformer.UI;
using Platformer.Units.Player;
using System;
using UnityEngine;

namespace Platformer.Factories
{
    public class GameFactory : IService
    {
        private readonly GameObject _playerPrefab;
        private readonly GameObject _hudPrefab;
        private readonly GameObject _startMenuPrefab;

        public event Action PlayerCreated;

        public GameObject PlayerGameObject { get; private set; }

        public GameFactory(GameObject playerPrefab, GameObject hudPrefab, GameObject startMenuPrefab)
        {
            _playerPrefab = playerPrefab;
            _hudPrefab = hudPrefab;
            _startMenuPrefab = startMenuPrefab;
        }

        public GameObject CreatePlayerAt(GameObject at, IInputService input)
        {
            PlayerGameObject = UnityEngine.Object.Instantiate(_playerPrefab, at.transform.position, at.transform.rotation);
            PlayerGameObject.GetComponent<PlayerMove>().Init(input);
            return PlayerGameObject;
        }

        public GameObject CreateHud(StartTrigger startTrigger, FinishTrigger finishTrigger)
        {
            GameObject hud = UnityEngine.Object.Instantiate(_hudPrefab);
            hud.GetComponent<TimerUI>().Init(startTrigger, finishTrigger);
            return hud;
        }

        public StartMenu CreateStartMenu() =>
            UnityEngine.Object.Instantiate(_startMenuPrefab).GetComponent<StartMenu>();
    }
}
