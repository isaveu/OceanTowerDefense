using System;
using UnityEngine;

namespace Player
{
    public class PlayerInputProvider : MonoBehaviour, IPlayerInputProvider
    {
        [SerializeField, Tooltip("Whether the tracking is enabled or not.")]
        private bool isEnabled;

        [SerializeField, Tooltip("The input configuration keys")]
        private PlayerInputConfiguration playerInputConfig;

        public event Action OnPressLeft = () => { };
        public event Action OnPressRight = () => { };
        public event Action OnPressUp = () => { };
        public event Action OnPressDown = () => { };
        public event Action OnPressJump = () => { };

        public bool IsEnabled
        {
            get => isEnabled;
            private set => isEnabled = value;
        }

        [Button]
        public void Enable()
        {
            IsEnabled = true;
        }

        [Button]
        public void Disable()
        {
            IsEnabled = false;
        }

        private void Awake()
        {
            Enable();
        }

        private void Update()
        {
            if (!IsEnabled)
                return;

            if (Input.GetKey(playerInputConfig.LeftKey))
                OnPressLeft.Invoke();

            if (Input.GetKey(playerInputConfig.RightKey))
                OnPressRight.Invoke();

            if (Input.GetKey(playerInputConfig.UpKey))
                OnPressUp.Invoke();

            if (Input.GetKey(playerInputConfig.DownKey))
                OnPressDown.Invoke();

            //Maybe replace KeyDown by Key.
            if (Input.GetKeyDown(playerInputConfig.JumpKey))
                OnPressJump.Invoke();
        }
    }
}