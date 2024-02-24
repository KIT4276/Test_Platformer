using System;
using UnityEngine;

namespace Platformer.UI
{
    public class StartMenu : MonoBehaviour
    {
        public event Action OnStarted;

        public void StartNewGameButtonDown()
        {
            //TODO

            ContinueGameButtonDown();
        }

        public void ContinueGameButtonDown()
        {
            OnStarted?.Invoke();
        }
    }
}
