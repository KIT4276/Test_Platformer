using Platformer.Service;
using Platformer.Service.Input;
using Platformer.UI;
using Platformer.Player;
using System;
using UnityEngine;
using Platformer.States;

namespace Platformer.Factories
{
    public class GameFactory : IService
    {
        private const string PlayerPrefabPath = "Prefabs/Player/Player";
        private const string HudPrefabPAth = "Prefabs/HUD";
        private const string StartMenuPrefabPath = "Prefabs/StartMenu";

        private readonly Death _death;
        private readonly Health _health;
        private readonly StateMachine _stateMachine;

        public event Action PlayerCreated;

        public GameObject PlayerGameObject { get; private set; }

        public GameFactory(Death death, Health health, StateMachine stateMachine)
        {
            _death = death;
            _health = health;
            _stateMachine = stateMachine;
        }

        public GameObject CreatePlayerAt(GameObject at, IInputService input)
        {
            PlayerGameObject = UnityEngine.Object.Instantiate(Resources.Load(PlayerPrefabPath) as GameObject, at.transform.position, at.transform.rotation);
            PlayerGameObject.GetComponent<PlayerMove>().Init(input);
            return PlayerGameObject;
        }

        public GameObject CreateHud()
        {
            GameObject hud = UnityEngine.Object.Instantiate(Resources.Load(HudPrefabPAth) as GameObject);
            hud.GetComponent<HealthUI>().Init(_health);
            hud.GetComponent<DeathUI>().Init(_death);
            hud.GetComponent<Pause>().Init(_stateMachine, _health);
            return hud;
        }

        public StartMenu CreateStartMenu() =>
            UnityEngine.Object.Instantiate(Resources.Load(StartMenuPrefabPath) as GameObject).GetComponent<StartMenu>();
    }
}
