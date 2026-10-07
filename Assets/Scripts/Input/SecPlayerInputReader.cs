using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DefaultNamespace
{
    public class SecPlayerInputReader : MonoBehaviour, Controls.I_2PlayerActions
    {
        private Controls _control;
        public event Action<Vector2> On2Dir;
        public event Action OnNum7Pressed;
        public event Action OnNum8Pressed;
        
        private void Awake()
        {
            _control = new Controls();
            _control._2Player.Enable();
            _control._2Player.SetCallbacks(this);
        }

        private void OnDestroy()
        {
            _control.Dispose();
            _control.Disable();
        }
        public void OnMove(InputAction.CallbackContext context)
        {
            On2Dir.Invoke(context.ReadValue<Vector2>());
        }

        public void OnNum7(InputAction.CallbackContext context)
        {
            if(context.performed)
                OnNum7Pressed?.Invoke();
        }

        public void OnNum8(InputAction.CallbackContext context)
        {
            if(context.performed)
                OnNum8Pressed?.Invoke();
        }
    }
}