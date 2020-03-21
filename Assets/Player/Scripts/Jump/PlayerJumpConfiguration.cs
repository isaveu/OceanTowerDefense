using UnityEngine;

namespace Player
{
    /// <summary>
    ///     The jump configurations of the player.
    /// </summary>
    [CreateAssetMenu(menuName = "Movement/Jump Configuration")]
    public class PlayerJumpConfiguration : ScriptableObject
    {
        [SerializeField, Range(1, 10)] private float jumpAcceleration;

        public float JumpAcceleration => jumpAcceleration;
    }
}