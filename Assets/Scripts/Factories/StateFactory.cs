using Platformer.States;
using Zenject;

namespace Platformer.Factories
{
    public class StateFactory 
    {
        private readonly DiContainer _container;

        public StateFactory(DiContainer container) =>
          _container = container;

        public T CreateState<T>() where T : IExitableState =>
            _container.Resolve<T>();
    }
}
