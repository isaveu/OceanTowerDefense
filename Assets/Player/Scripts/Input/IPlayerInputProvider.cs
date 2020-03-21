using System;

namespace Player
{
    /// <summary>
    ///     Provides the movement input of a character.
    /// </summary>
    public interface IPlayerInputProvider
    {
        /// <summary>
        ///     Whether the movement input is enabled.
        /// </summary>
        bool IsEnabled { get; }

        /// <summary>
        ///     Dispatched whenever the key is pressed.
        /// </summary>
        event Action OnPressLeft;

        /// <summary>
        ///     Dispatched whenever the key is pressed.
        /// </summary>
        event Action OnPressRight;

        /// <summary>
        ///     Dispatched whenever the key is pressed.
        /// </summary>
        event Action OnPressUp;

        /// <summary>
        ///     Dispatched whenever the key is pressed.
        /// </summary>
        event Action OnPressDown;

        /// <summary>
        ///     Dispatched whenever the key is pressed.
        /// </summary>
        event Action OnPressJump;

        /// <summary>
        ///     Disables and resets all the input.
        /// </summary>
        void Disable();

        /// <summary>
        ///     Enables the input.
        /// </summary>
        void Enable();
    }
}