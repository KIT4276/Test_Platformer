using Platformer.Triggers;
using TMPro;
using UnityEngine;

namespace Platformer.UI
{
    public class TimerUI : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _text;

        private StartTrigger _startTrigger;
        private FinishTrigger _finishTrigger;

        private float _time;
        private bool _isSterted;

        internal void Init(StartTrigger startTrigger, FinishTrigger finishTrigger)
        {
            _startTrigger = startTrigger;
            _finishTrigger = finishTrigger;

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
