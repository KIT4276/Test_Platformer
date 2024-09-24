using UnityEngine;

namespace Platformer.Player
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private static readonly int MoveHash = Animator.StringToHash("Moving");
        private static readonly int JumpHash = Animator.StringToHash("Jump");

        public void PlayMove(bool isMoving) =>
            _animator.SetBool(MoveHash, isMoving);

        public void PlayJump() =>
            _animator.SetTrigger(JumpHash);
    }
}
