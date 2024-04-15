using DG.Tweening;
using System.Collections;
using UnityEngine;

namespace Platformer.Logic
{
    public class LoadingAnimation : MonoBehaviour
    {
        [SerializeField] private float _duration = 1;
        [SerializeField] private RectTransform _image;

        private void Awake() => 
            StartCoroutine(RotateImage());

        private IEnumerator RotateImage()
        {
            while (true)
            {
                _image.DORotate(new Vector3(0, 0, _image.rotation.eulerAngles.z - 180), _duration);
                yield return null;
            }
        }

        private void OnDisable() => 
            StopCoroutine(RotateImage());
    }
}
