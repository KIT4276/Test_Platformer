using UnityEngine;

namespace Platformer.Triggers
{
    public class RotatingPlatformTrigger : Trap
    {
        [SerializeField]
        private float _rotateSpeed = 1;
        [SerializeField]
        private Transform _platformsTransform;

        private int _durationIndex;
        private Quaternion _targetRotation;

        private float _addedRotation;
        private float _rotateX;
        private float _rotateY;
        private float _rotateZ;

        private void Awake()
        {
            _addedRotation = _rotateSpeed * Time.deltaTime;
            _rotateY = transform.rotation.eulerAngles.y;
        }

        protected override void LaunchTrap()
        {
            if (!_isActive)
                _durationIndex = Random.Range(1, 5);
            
            _isActive = true;
        }

        private void Update()
        {
            if (_isActive)
            {
                RotationSelection();
               
                _platformsTransform.rotation = _targetRotation;
            }
        }

        private void RotationSelection()
        {
            _rotateX = _platformsTransform.rotation.eulerAngles.x;
            _rotateZ = _platformsTransform.rotation.eulerAngles.z;

            switch (_durationIndex)
            {
                case 1:
                    _targetRotation = Quaternion.Euler(new Vector3
                        (_rotateX + _addedRotation, _rotateY, _rotateZ));
                    break;
                case 2:
                    _targetRotation = Quaternion.Euler(new Vector3
                        (_rotateX - _addedRotation, _rotateY, _rotateZ));
                    break;
                case 3:
                    _targetRotation = Quaternion.Euler(new Vector3
                        (_rotateX, _rotateY, _rotateZ + _addedRotation));
                    break;
                case 4:
                    _targetRotation = Quaternion.Euler(new Vector3
                        (_rotateX, _rotateY, _rotateZ - _addedRotation));
                    break;

                default:
                    break;
            }
        }

        protected override void StopTrap()
        {
            _isActive = false;
        }
    }
}
