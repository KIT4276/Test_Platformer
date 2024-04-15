using Platformer.Service;
using Platformer.States;
using UnityEngine;

namespace Platformer.UI
{
    public class Pause : MonoBehaviour
    {
        [SerializeField] private GameObject _pausePanel;

        private bool _isPaused;
        private StateMachine _stateMachine;
        private Health _health;

        public void Init(StateMachine stateMachine, Health health)
        {
            _stateMachine = stateMachine;
            _health = health;
        }

        private void Start() =>
            _pausePanel.gameObject.SetActive(false);

        private void Update() =>
            ChekInput();

        public void OnPause()
        {
            _isPaused = true;
            Time.timeScale = 0;
            _pausePanel.SetActive(true);
        }

        public void OfPause()
        {
            _isPaused = false;
            Time.timeScale = 1;
            _pausePanel.SetActive(false);
        }

        public void Exit() =>
            Application.Quit();

        public void Restart()
        {
            _health.Restart();

            _stateMachine.Enter<BootstrapState>();
        }

        private void ChekInput()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!_isPaused)
                    OnPause();
                else
                    OfPause();
            }
        }
    }
}
