using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerInputProvider)), RequireComponent(typeof(Rigidbody))]
    public class PlayerJump : MonoBehaviour
    {
        private PlayerInputProvider _inputProvider;
        private Rigidbody _rigidbody;
        [SerializeField] private PlayerJumpConfiguration jumpConfigs;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _inputProvider = GetComponent<PlayerInputProvider>();
            SubscribeInput();
        }

        private void SubscribeInput()
        {
            _inputProvider.OnPressJump += Jump;
        }

        private void UnsubscribeInput()
        {
            _inputProvider.OnPressJump -= Jump;
        }

        private void Jump()
        {
            Debug.Log("Jump");
            var velocity = _rigidbody.velocity;
            velocity.y += jumpConfigs.JumpAcceleration;
            _rigidbody.velocity = velocity;
        }


        private void OnDestroy()
        {
            UnsubscribeInput();
        }
    }
}