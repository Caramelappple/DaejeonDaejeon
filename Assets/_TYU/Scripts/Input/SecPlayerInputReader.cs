using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DefaultNamespace
{
    public class SecPlayerInputReader : AbstractInput, Controls.I_2PlayerActions
    {
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
            MoveInvoke(context.ReadValue<Vector2>());
        }

        public void OnNum7(InputAction.CallbackContext context)
        {
            if(context.performed)
                AttackInvoke();
        }

        public void OnNum8(InputAction.CallbackContext context)
        {
            if(context.performed)
                DashInvoke();
        }
    }
}