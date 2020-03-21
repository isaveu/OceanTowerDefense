using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerInputProvider)), RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        private PlayerInputProvider _inputProvider;
        private Rigidbody _rigidbody;
        [SerializeField] private PlayerMovementConfiguration movementConfigs;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _inputProvider = GetComponent<PlayerInputProvider>();
            SubscribeInput();
        }

        private void SubscribeInput()
        {
            _inputProvider.OnPressLeft += MoveLeft;
            _inputProvider.OnPressRight += MoveRight;
            _inputProvider.OnPressUp += MoveUp;
            _inputProvider.OnPressDown += MoveDown;
        }

        private void UnsubscribeInput()
        {
            _inputProvider.OnPressLeft -= MoveLeft;
            _inputProvider.OnPressRight -= MoveRight;
            _inputProvider.OnPressUp -= MoveUp;
            _inputProvider.OnPressDown -= MoveDown;
        }

        private void MoveLeft()
        {
            Debug.Log("Move Left");
            if (!SmallerThanMaxVelocityXAndZ())
                return;

            var velocity = _rigidbody.velocity;
            velocity.x -= movementConfigs.Acceleration;
            _rigidbody.velocity = velocity;
        }


        private void MoveRight()
        {
            if (!SmallerThanMaxVelocityXAndZ())
                return;
            Debug.Log("Move Right");
            var velocity = _rigidbody.velocity;
            velocity.x += movementConfigs.Acceleration;
            _rigidbody.velocity = velocity;
        }

        private void MoveUp()
        {
            if (!SmallerThanMaxVelocityXAndZ())
                return;
            Debug.Log("Move Up");
            var velocity = _rigidbody.velocity;
            velocity.z += movementConfigs.Acceleration;
            _rigidbody.velocity = velocity;
        }

        private void MoveDown()
        {
            if (!SmallerThanMaxVelocityXAndZ())
                return;
            Debug.Log("Move Down");
            var velocity = _rigidbody.velocity;
            velocity.z -= movementConfigs.Acceleration;
            _rigidbody.velocity = velocity;
        }

        private bool SmallerThanMaxVelocityXAndZ()
        {
            var velocity = _rigidbody.velocity;
            velocity.y = 0; //nullify the Y component
            return velocity.magnitude < movementConfigs.MaxVelocity;
        }

        private void OnDestroy()
        {
            UnsubscribeInput();
        }
    }
}