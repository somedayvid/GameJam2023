using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHUDPenguin : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((UnityEngine.InputSystem.Keyboard.current.wKey.isPressed) ||
            (UnityEngine.InputSystem.Keyboard.current.aKey.isPressed) ||
            (UnityEngine.InputSystem.Keyboard.current.sKey.isPressed) || 
            (UnityEngine.InputSystem.Keyboard.current.dKey.isPressed))
        {
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }
}
