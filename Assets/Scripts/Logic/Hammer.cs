using DG.Tweening;
using UnityEngine;

namespace Platformer.Logic
{
    public class Hammer : MonoBehaviour
    {
        [SerializeField] private Transform _hummer;
        [SerializeField] private float _rotateDuration;
        [SerializeField] private float _angle = 80;

        private void Start() => 
            MoveHummerR();

        private void MoveHummerR() => 
            _hummer.DORotate(new Vector3(0, 0, _angle), _rotateDuration, RotateMode.LocalAxisAdd).onComplete = MoveHummerL;

        private void MoveHummerL() => 
            _hummer.DORotate(new Vector3(0, 0, -_angle), _rotateDuration, RotateMode.LocalAxisAdd).onComplete = MoveHummerR;
    }
}
