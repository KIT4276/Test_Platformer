using UnityEngine;

namespace Platformer.Service.Input
{
    public interface IInputService : IService
    {
        Vector2 Axis { get; }

        bool IsJumpButtonUp();
    }
}
