using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHUDPenguin : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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

        
        if (UnityEngine.InputSystem.Keyboard.current.aKey.isPressed)
        {
            spriteRenderer.flipX = true;
        }
        /*
        else if (UnityEngine.InputSystem.Keyboard.current.dKey.isPressed)
        {
            spriteRenderer.flipX = false;
        }
        */
        
        /*
        // Flip the sprite only if the current direction is different from the previous direction and not zero
        if ((direction < 0f) != spriteRenderer.flipX && direction != 0f)
        {
            spriteRenderer.flipX = direction < 0f;
        }
        */
    }
}
