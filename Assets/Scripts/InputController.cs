using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class InputController : MonoBehaviour
{
    [SerializeField] MovementController movementController;

    public void OnMove(InputAction.CallbackContext context)
    {
        movementController.ObjectDirection = context.ReadValue<Vector2>();
    }

    public void onAim(InputAction.CallbackContext context)
    {
        Vector2 mousePosition = context.ReadValue<Vector2>();
    }

    public void useAbilities(InputAction.CallbackContext context)
    {

    }
}
