using Platformer.Triggers;
using TMPro;
using UnityEngine;

namespace Platformer.UI
{
    public class TimerUI : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _text;
        [SerializeField]
        private StartTrigger _startTrigger;
        [SerializeField]
        private FinishTrigger _finishTrigger;

        private float _time;
        private bool _isSterted;

        private void Start()
        {
            _startTrigger.MainGameTriggerEnteredE += StartTimer;
        }

        private void StartTimer()
        {
            _startTrigger.MainGameTriggerEnteredE -= StartTimer;
            _isSterted = true;
            _finishTrigger.MainGameTriggerEnteredE += StopTimer;
        }

        private void StopTimer()
        {
            _isSterted = false;
            _finishTrigger.MainGameTriggerEnteredE -= StopTimer;
        }

        private void Update()
        {

            if (_isSterted)
            {
                _time += Time.deltaTime;
                _text.text = _time.ToString("00.00");
            }
            
        }
    }
}
