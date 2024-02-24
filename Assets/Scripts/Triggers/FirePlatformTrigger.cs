using Platformer.Service;
using System.Collections;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Platformer.Triggers
{
    public class FirePlatformTrigger : Trap
    {
        [SerializeField]
        private MeshRenderer _mesh;

        [Space, SerializeField]
        protected Material _normalMaterial;
        [SerializeField]
        protected Material _activeMaterial;
        [SerializeField]
        protected Material _fireMaterial;

        [SerializeField]
        private float _reloadTime = 5;
        [Space, SerializeField]
        private float _fireTime = 0.1f;
        [SerializeField]
        private float _damage = 5;
        [SerializeField]
        private float _fireDelay = 1;

        [Inject]
        private Health _health;

        private Material[] _meshMaterials = new Material[4];

        protected override void LaunchTrap()
        {
            if(!_isActive)
            StartCoroutine(TrapCoroutine());
        }

        protected override void StopTrap()
        {
            _isActive = false;
            RemoveMaterial();
            AddMaterial(_normalMaterial);
        }

        private IEnumerator TrapCoroutine()
        {
            _isActive = true;
            AddMaterial(_activeMaterial);

            yield return new WaitForSeconds(_fireDelay);

            while (_isActive)
            {
                AddMaterial(_fireMaterial);
                _health.SetDamage(_damage);
                yield return new WaitForSeconds(_fireTime);
                AddMaterial(_activeMaterial);
                yield return new WaitForSeconds(_reloadTime);
            }
        }

        private void AddMaterial(Material material)
        {
            _meshMaterials[1] = material;
            _mesh.materials = _meshMaterials.Where(t => t != null).ToArray();
        }

        private void RemoveMaterial()
        {
            _meshMaterials[1] = null;
            _mesh.materials = _meshMaterials.Where(t => t != null).ToArray();
        }
    }
}
