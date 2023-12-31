using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using UnityEditor;

public class InputController : MonoBehaviour
{
    [SerializeField] MovementController movementController;
    [SerializeField] Attacks attacks;

    public bool isExploding;
    private float cooldownTime = .75f;
    private bool isCooldown = false;


    private void Start()
    {
        attacks = GetComponent<Attacks>(); 
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    public void OnMove(InputAction.CallbackContext context)
    {
        movementController.SetDirection(context.ReadValue<Vector2>());
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    public void onAim(InputAction.CallbackContext context)
    {
        context.action.performed += ctx =>
        {
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Debug.Log("Your mouse position is: " + mousePosition);
            if (!isCooldown)
            {
                attacks.AOEExplosion(onAim(), .55f);
                StartCoroutine(Cooldown());
            }

        };

    }

    public Vector2 onAim()
    {
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            return mousePosition;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    public void useAbilities(InputAction.CallbackContext context)
    {
        attacks = GetComponent<Attacks>();
        context.action.performed += ctx =>
        {
            switch (ctx.control.name)
            {
                case "1":
                    Debug.Log("You pressed 1");
                    //OnAim for mouse posistion and then a lifetime
                    //attacks.FireShot(onAim(), 5f);

                    
                    break;
                case "2":
                    Debug.Log("You pressed 2");
                   // attacks.AOEExplosion(onAim(), 1f);

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

    private IEnumerator Cooldown()
    {
        isCooldown = true;
        yield return new WaitForSeconds(cooldownTime);
        isCooldown = false;
    }
    
}
