using Platformer.Service;
using Platformer.Service.Input;
using Platformer.UI;
using Platformer.Player;
using System;
using UnityEngine;

namespace Platformer.Factories
{
    public class GameFactory : IService
    {
        private readonly GameObject _playerPrefab;
        private readonly GameObject _hudPrefab;
        private readonly GameObject _startMenuPrefab;
        private readonly Death _death;
        private readonly Health _health;

        public event Action PlayerCreated;

        public GameObject PlayerGameObject { get; private set; }

        public GameFactory(GameObject playerPrefab, GameObject hudPrefab, GameObject startMenuPrefab,
            Death death, Health health)
        {
            _playerPrefab = playerPrefab;
            _hudPrefab = hudPrefab;
            _startMenuPrefab = startMenuPrefab;
            _death = death;
            _health = health;
        }

        public GameObject CreatePlayerAt(GameObject at, IInputService input)
        {
            PlayerGameObject = UnityEngine.Object.Instantiate(_playerPrefab, at.transform.position, at.transform.rotation);
            PlayerGameObject.GetComponent<PlayerMove>().Init(input, _death);
            return PlayerGameObject;
        }

        public GameObject CreateHud(GameObject player)
        {
            GameObject hud = UnityEngine.Object.Instantiate(_hudPrefab);
            hud.GetComponent<Hud>().Init(player);
            hud.GetComponent<HealthUI>().Init(_health);
            hud.GetComponent<DeathUI>().Init(_death);
            return hud;
        }

        public StartMenu CreateStartMenu() =>
            UnityEngine.Object.Instantiate(_startMenuPrefab).GetComponent<StartMenu>();
    }
}
