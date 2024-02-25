using UnityEngine;

namespace Platformer.Logic
{
    public class CameraFollow : MonoBehaviour
    {
        private Transform _folowing;

        [Space, SerializeField]
        private float RotationAngleX = 50;
        [SerializeField]
        private float Ditance = 7;
        [SerializeField]
        private float OffsetY = 5;
        [SerializeField]
        private float _speed = 2;

        public void Follow(Transform transform) => 
            _folowing = transform;

        private void LateUpdate()
        {
            if (_folowing == null)
                return;

            Quaternion rotation = Quaternion.Euler(RotationAngleX, 0, 0);
            Vector3 position = rotation * new Vector3(0, 0, -Ditance) + FollowingPointPosition();

            transform.rotation = rotation;
            transform.position = Vector3.Lerp(transform.position, position, _speed * Time.deltaTime);
        }

        private Vector3 FollowingPointPosition()
        {
            Vector3 followingPosition = _folowing.position;
            followingPosition.y += OffsetY;
            return followingPosition;
        }
    }
}
