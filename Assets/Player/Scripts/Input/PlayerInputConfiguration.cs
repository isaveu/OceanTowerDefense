using UnityEngine;

namespace Player
{
    [CreateAssetMenu(menuName = "Movement/Input")]
    public class PlayerInputConfiguration : ScriptableObject
    {
        [SerializeField, Tooltip("The key to move down.")]
        private KeyCode downKey = KeyCode.S;

        [SerializeField, Tooltip("The key to jump.")]
        private KeyCode jumpKey = KeyCode.Space;

        [SerializeField, Tooltip("The key to move left.")]
        private KeyCode leftKey = KeyCode.A;

        [SerializeField, Tooltip("The key to move right.")]
        private KeyCode rightKey = KeyCode.D;

        [SerializeField, Tooltip("The key to move up.")]
        private KeyCode upKey = KeyCode.W;

        public KeyCode LeftKey => leftKey;

        public KeyCode RightKey => rightKey;

        public KeyCode UpKey => upKey;

        public KeyCode DownKey => downKey;

        public KeyCode JumpKey => jumpKey;
    }
}