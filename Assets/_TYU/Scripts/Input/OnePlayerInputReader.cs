using UnityEngine;
using UnityEngine.InputSystem;

public class OnePlayerInputReader : AbstractInput, Controls.I_1PlayerActions
{
    private void Awake()
    {
        _control = new Controls();
        _control._1Player.Enable();
        _control._1Player.SetCallbacks(this);
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

    public void OnJ(InputAction.CallbackContext context)
    {
        if(context.performed)
            AttackInvoke();
        
    }

    public void OnH(InputAction.CallbackContext context)
    {
        if(context.performed)
            DashInvoke();
    }
}