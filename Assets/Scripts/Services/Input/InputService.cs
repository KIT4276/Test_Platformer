using UnityEngine;

namespace Platformer.Service.Input
{
    public abstract class InputService : IInputService
    {
        private const string JumpButton = "Jump";
        protected const string Horizontal = "Horizontal";
        protected const string Vertical = "Vertical";

        public abstract Vector2 Axis { get; }

        public bool IsJumpButtonUp() =>
            SimpleInput.GetButtonUp(JumpButton);

        protected static Vector2 SimpleInputAxis() =>
            new(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));

    }
}

