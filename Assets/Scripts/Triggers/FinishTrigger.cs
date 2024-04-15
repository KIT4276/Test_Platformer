using UnityEngine;

namespace Platformer.Triggers
{
    public class FinishTrigger : MainGameTrigger
    {
        [SerializeField] private GameObject _finMessage;

        private void Start() =>
            _finMessage.SetActive(false);

        protected override void TriggerEnter()
        {
            _finMessage.transform.parent = null;
            _finMessage.SetActive(true);
            _finMessage.GetComponent<WinUI>().Win();
        }
    }
}
