using UnityEngine;

namespace Platformer
{
    [ExecuteInEditMode]
    public class RandomRotate : MonoBehaviour
    {
        void Start()
        {
            var r = Random.Range(-45, 45);
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, r, transform.rotation.eulerAngles.z);
        }
    }
}
