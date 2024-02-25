using Platformer.Service;
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
        private Timer _timer;

        public void Win() => 
            _text.text = _timer.Min.ToString() + " : " + _timer.Sec.ToString();
    }
}
