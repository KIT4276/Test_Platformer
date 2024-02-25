using System.Collections;
using UnityEngine;

namespace Platformer
{
    public class LoadingVignetteCurtain : MonoBehaviour
    {
        [SerializeField]
        private CanvasGroup Curtain;
        [SerializeField]
        private float _step = 0.03f;
        [SerializeField]
        private float _delay = 0.03f;
        [SerializeField]
        private AudioSource _audio;


        public void HideVignette() =>
            StartCoroutine(DoFadeOut());

        public void ShowVignette() =>
            StartCoroutine(DoFadeIn());

        private IEnumerator DoFadeIn()
        {
            _audio.volume = 0;
            
            while (Curtain.alpha < 1)
            {
                Curtain.alpha += _step;
                _audio.volume += _step;
                yield return new WaitForSeconds(_delay);
            }
        }

        private IEnumerator DoFadeOut()
        {
            while (Curtain.alpha > 0)
            {
                Curtain.alpha -= _step;
                _audio.volume -= _step;
                yield return new WaitForSeconds(_delay);
            }
        }
    }
}
