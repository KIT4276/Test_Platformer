using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Platformer.UI
{
    public class ButtonesView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] protected Image _buttosesImage;
        [SerializeField] protected Sprite _unenteredSprite;
        [SerializeField] protected Sprite _enteredSprite;

        protected void Awake() => 
            _buttosesImage.sprite = _unenteredSprite;

        public void OnPointerEnter(PointerEventData eventData) => 
            _buttosesImage.sprite = _enteredSprite;

        public void OnPointerExit(PointerEventData eventData) => 
            _buttosesImage.sprite = _unenteredSprite;
    }
}
