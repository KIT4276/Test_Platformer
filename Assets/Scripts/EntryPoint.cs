using Platformer.States;
using UnityEngine;
using Zenject;

namespace Platformer
{
    public class EntryPoint : MonoBehaviour
    {
        [Inject]
        private DiContainer _container;

        private void Start()
        {
            while (_container.Resolve<StateMachine>() == null)
                Debug.Log("wait for StateMachine");

            _container.Resolve<StateMachine>().Initialize();
        }
    }
}
