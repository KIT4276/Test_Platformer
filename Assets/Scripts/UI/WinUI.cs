using Platformer.Service;
using Platformer.States;
using TMPro;
using UnityEngine;
using Zenject;

namespace Platformer
{
    public class WinUI : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _text;

        [Inject]
        private readonly Timer _timer;
        [Inject]
        private readonly StateMachine _stateMachine;

        public void Win() => 
            _text.text = _timer.Min.ToString() + " : " + _timer.Sec.ToString();

        public void Restart() => 
            _stateMachine.Enter<BootstrapState>();
    }
}
