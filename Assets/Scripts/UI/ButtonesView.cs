using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Platformer.UI
{
    public class ButtonesView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private Image _buttosesImage;
        [SerializeField] private Sprite _unenteredSprite;
        [SerializeField] private Sprite _enteredSprite;

        private void Awake() => 
            _buttosesImage.sprite = _unenteredSprite;

        public void OnPointerEnter(PointerEventData eventData) => 
            _buttosesImage.sprite = _enteredSprite;

        public void OnPointerExit(PointerEventData eventData) => 
            _buttosesImage.sprite = _unenteredSprite;
    }
}
