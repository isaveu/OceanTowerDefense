using UnityEngine;

namespace NaughtyCharacter
{
    public class TestHelper : MonoBehaviour
    {
        [SerializeField] private float _slowMotion = 0.1f;

        [SerializeField] private int _targetFrameRate = 60;

        protected virtual void Awake()
        {
            Application.targetFrameRate = _targetFrameRate;
        }

        protected virtual void Update()
        {
            if (Input.GetButtonDown("Slow Motion")) ToggleSlowMotion();
        }

        private void ToggleSlowMotion()
        {
            Time.timeScale = Time.timeScale == 1f ? _slowMotion : 1f;
        }
    }
}