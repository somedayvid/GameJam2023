using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    // Variable field
    [SerializeField] float speed = 5f;
    private SpriteRenderer spriteRenderer;

    private Camera cam;
    private float camHeight;
    private float camWidth;

    private Vector3 objectPosition = Vector3.zero;
    private Vector3 direction = Vector3.zero;
    private Vector3 velocity = Vector3.zero;

    public Vector2 moveInput;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        cam = Camera.main;

        camHeight = 2.0f * cam.orthographicSize;
        camWidth = camHeight * cam.aspect;

        objectPosition = transform.position;

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        velocity = speed * Time.deltaTime * direction;
        objectPosition += velocity;
        transform.position = objectPosition;

        // Clamp the x and y values to camera view
        objectPosition.x = Mathf.Clamp(objectPosition.x, cam.transform.position.x - camWidth / 2, cam.transform.position.x + camWidth / 2);
        objectPosition.y = Mathf.Clamp(objectPosition.y, cam.transform.position.y - camHeight / 2, cam.transform.position.y + camHeight / 2);

        // Assign the clamped object position to the object's transform
        transform.position = objectPosition;

        if (Input.GetKey(KeyCode.W) ||
            Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.S) ||
            Input.GetKey(KeyCode.D))
        {
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }

    /// <summary>
    /// Sets the new direction of the object
    /// </summary>
    /// <param name="newDirection">A vector3 of the direction</param>
    public void SetDirection(Vector3 newDirection)
    {
        if (newDirection != null)
        {
            direction = newDirection.normalized;

            // Flip the sprite only if the current direction is different from the previous direction and not zero
            if ((direction.x < 0f) != spriteRenderer.flipX && direction.x != 0f)
            {
                spriteRenderer.flipX = direction.x < 0f;
            }
        }
    }
}