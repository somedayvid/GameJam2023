using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class InputController : MonoBehaviour
{
    [SerializeField]
    MovementController movementController;

    public void OnMove(InputAction.CallbackContext context)
    {
        movementController.ObjectDirection = context.ReadValue<Vector2>();
    }
}
