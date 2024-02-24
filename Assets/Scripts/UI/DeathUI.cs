using Platformer.Service;
using System;
using System.Collections;
using UnityEngine;

namespace Platformer.UI
{
    public class DeathUI : MonoBehaviour
    {
        [SerializeField]
        private CanvasGroup _curtain;
        [SerializeField]
        private GameObject _curtainObj;

        private Death _death;

        public event Action FadeInE;

        public void Init(Death death)
        {
            _death = death;

            _death.OnDeadE += Show;
        }

        public void Show()
        {
            _curtainObj.SetActive(true);
            
            StartCoroutine(DoFadeIn());
        }


        private IEnumerator DoFadeIn()
        {
            while (_curtain.alpha < 1)
            {
                _curtain.alpha += 0.03f;
                yield return new WaitForSeconds(0.01f);
            }

            yield return new WaitForSeconds(2f);
            _death.EndDeath();
        }
    }
}
