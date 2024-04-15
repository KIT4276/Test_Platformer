using Platformer.Logic;
using Platformer.Triggers;
using System.Collections;
using UnityEngine;

namespace Platformer.Service 
{
    public class Timer : IService
    {
        private StartTrigger _startTrigger;
        private FinishTrigger _finishTrigger;

        private readonly ICoroutineRunner _coroutine;

        private bool _isStarted;

        public int Sec { get; private set; }
        public int Min { get; private set; }

        public Timer(ICoroutineRunner coroutine) => 
            _coroutine = coroutine;

        public void Init(StartTrigger startTrigger, FinishTrigger finishTrigger)
        {
            _startTrigger = startTrigger;
            _finishTrigger = finishTrigger;

            _startTrigger.MainGameTriggerEnteredE += StartTimer;
        }

        private void StartTimer()
        {
            _startTrigger.MainGameTriggerEnteredE -= StartTimer;
            _isStarted = true;
            _coroutine.StartCoroutine(TimeFlow());
            _finishTrigger.MainGameTriggerEnteredE += StopTimer;
        }

        private IEnumerator TimeFlow()
        {
            while (_isStarted)
            {
                if (Sec == 59)
                {
                    Min++;
                    Sec = -1;
                }
                Sec++;

                yield return new WaitForSeconds(1);
            }
        }

        private void StopTimer()
        {
            _isStarted = false;
            _finishTrigger.MainGameTriggerEnteredE -= StopTimer;
        }
    }
}
