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
        movementController.SetDirection(context.ReadValue<Vector2>());
    }

    public void onAim(InputAction.CallbackContext context)
    {
        context.action.performed += ctx =>
        {
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Debug.Log("Your mouse position is: " + mousePosition);
        };

    }

    public void useAbilities(InputAction.CallbackContext context)
    {

    }
}
