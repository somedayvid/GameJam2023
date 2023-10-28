using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using UnityEditor;

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
        context.action.performed += ctx =>
        {
            switch (ctx.control.name)
            {
                case "1":
                    Debug.Log("You pressed 1");
                    break;
                case "2":
                    Debug.Log("You pressed 2");
                    break;
                case "3":
                    Debug.Log("You pressed 3");
                break;
                case "4":
                    Debug.Log("You pressed 4");
                break;
            }
        };
    }
}
