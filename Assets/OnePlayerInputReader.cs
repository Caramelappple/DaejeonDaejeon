using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class OnePlayerInputReader : MonoBehaviour, Controls.I_1PlayerActions
{
    public event Action<Vector2> On1Dir;
    public event Action OnJPressed;
    public event Action OnHPressed;
    
    private Controls _control;

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
        On1Dir.Invoke(context.ReadValue<Vector2>());
    }

    public void OnJ(InputAction.CallbackContext context)
    {
        if(context.performed)
            OnJPressed?.Invoke();
        
    }

    public void OnH(InputAction.CallbackContext context)
    {
        if(context.performed)
            OnHPressed?.Invoke();
    }
}
