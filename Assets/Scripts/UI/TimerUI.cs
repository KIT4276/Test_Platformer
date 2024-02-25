using TMPro;
using UnityEngine;

namespace Platformer.UI
{
    public class TimerUI : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _text;

        /// In case you need to display the timer during the game
        /// 

        //private StartTrigger _startTrigger;
        //private FinishTrigger _finishTrigger;

        //private float _time;
        //private int _sec;
        //private int _min;

        //private bool _isStarted;

        //public void Init(StartTrigger startTrigger, FinishTrigger finishTrigger)
        //{
        //    _startTrigger = startTrigger;
        //    _finishTrigger = finishTrigger;

        //    _startTrigger.MainGameTriggerEnteredE += StartTimer;
        //}

        //private void StartTimer()
        //{
        //    _startTrigger.MainGameTriggerEnteredE -= StartTimer;
        //    _isStarted = true;
        //    StartCoroutine(TimeFlow());
        //    _finishTrigger.MainGameTriggerEnteredE += StopTimer;
        //}

        //private IEnumerator TimeFlow()
        //{
        //    while (_isStarted)
        //    {
        //        if (_sec == 59)
        //        {
        //            _min++;
        //            _sec = -1;
        //        }
        //        _sec++;


        //       yield return new WaitForSeconds(1);
        //    }
        //}

        //private void StopTimer()
        //{
        //    _isStarted = false;
        //    StopCoroutine(TimeFlow());
        //    _finishTrigger.MainGameTriggerEnteredE -= StopTimer;
        //}

    }
}
