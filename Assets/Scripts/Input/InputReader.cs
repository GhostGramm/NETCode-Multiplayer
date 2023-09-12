using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static Controls;

[CreateAssetMenu(fileName = "New Input Reader", menuName = "Input/Input Reader")]
public class InputReader : ScriptableObject, IPlayerActions
{
    public Action<bool> OnPrimaryEvent;
    public Action<Vector2> OnMoveEvent;

    private Controls controls;

    private void OnEnable()
    {
        if(controls == null)
        {
            controls = new Controls();
            controls.Player.SetCallbacks(this);
        }

        controls.Player.Enable();
    }
     
    public void OnMove(InputAction.CallbackContext context)
    {
         OnMoveEvent?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnPrimaryFire(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            OnPrimaryEvent?.Invoke(true);
        }
        else
        {
            OnPrimaryEvent?.Invoke(false);
        }
    }
}
