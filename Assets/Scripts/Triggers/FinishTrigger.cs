using System;
using UnityEngine;

namespace Platformer.Triggers
{
    public class FinishTrigger : MainGameTrigger
    {
        [SerializeField]
        private GameObject _finMessage;

        

        protected override void TriggerEnter()
        {
            _finMessage.SetActive(true);
        }
    }
}
