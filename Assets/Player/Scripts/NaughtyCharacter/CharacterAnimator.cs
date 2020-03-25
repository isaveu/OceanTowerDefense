using UnityEngine;

namespace NaughtyCharacter
{
    public static class CharacterAnimatorParamId
    {
        public static readonly int IsMoving = Animator.StringToHash("IsMoving");
    }

    public class CharacterAnimator : MonoBehaviour
    {
        private Animator _animator;
        private Character _character;

        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
            _character = GetComponent<Character>();
        }

        public void UpdateState()
        {
            var normHorizontalSpeed =
                _character.HorizontalVelocity.magnitude / _character.MovementSettings.MaxHorizontalSpeed;
            _animator.SetBool(CharacterAnimatorParamId.IsMoving, normHorizontalSpeed > 0);
        }
    }
}