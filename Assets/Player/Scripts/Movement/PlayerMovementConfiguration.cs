using UnityEngine;

namespace Player
{
    /// <summary>
    ///     The movement configurations of the player.
    /// </summary>
    [CreateAssetMenu(menuName = "Movement/Movement Configuration")]
    public class PlayerMovementConfiguration : ScriptableObject
    {
        [SerializeField, Range(0.01f, 1f)] private float acceleration;
        [SerializeField, Range(1, 10)] private float maxVelocity;

        public float Acceleration => acceleration;
        public float MaxVelocity => maxVelocity;
    }
}