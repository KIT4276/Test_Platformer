using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Platformer.UI
{
    public class ButtonesPressView : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private float _delayTime = 0.1f;
        [SerializeField] protected Image _buttosImage;
        [SerializeField] protected Sprite _unpressedSprite;
        [SerializeField] protected Sprite _pressedSprite;

        public void OnPointerClick(PointerEventData eventData) => 
            StartCoroutine(ChangeImage());

        private IEnumerator ChangeImage()
        {
            _buttosImage.sprite = _pressedSprite;
            yield return new WaitForSeconds(_delayTime);
            _buttosImage.sprite = _unpressedSprite;
        }
    }
}
