using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    Vector3 objectPosition = Vector3.zero;
    Vector3 direction = Vector3.right;
    Vector3 velocity = Vector3.zero;

    float screenHeight;
    float screenWidth;

    [SerializeField]
    float speed = 0;

    [SerializeField]
    Vector2 rectSize = new Vector2(.7f, 1.3f);

    /// <summary>
    /// Direction Property for Controller to change direction
    /// </summary>
    public Vector3 ObjectDirection
    {
        set
        {
            if (value != null)
            {
                direction = value.normalized;
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        objectPosition = transform.position;

        screenHeight = 2f * Camera.main.orthographicSize;
        screenWidth = screenHeight * Camera.main.aspect;
    }
    // Update is called once per frame
    void Update()
    {
        //Move Object
        velocity = direction * speed * Time.deltaTime;
        objectPosition += velocity;
        transform.position = objectPosition;

        //Warp Around Screem X


        if (transform.position.x < -(screenWidth / 2) + 1.5f)
        {
            /*
            objectPosition.x += screenWidth;
            transform.position = objectPosition;
            */

            speed = 0;

            if (speed == 0 && UnityEngine.InputSystem.Keyboard.current.dKey.wasPressedThisFrame)
            {
                speed = 6;
            }
        }
        else if (transform.position.x > (screenWidth / 2) - 2f)
        {
            /*
            objectPosition.x -= screenWidth;
            transform.position = objectPosition;
            */

            speed = 0;

            if (speed == 0 && UnityEngine.InputSystem.Keyboard.current.aKey.wasPressedThisFrame)
            {
                speed = 6;
            }
        }
        //Warp Around Screen Y
        if (transform.position.y < -(screenHeight / 2))
        {
            objectPosition.y += screenHeight;
            transform.position = objectPosition;
        }
        else if (transform.position.y > screenHeight / 2)
        {
            objectPosition.y -= screenHeight;
            transform.position = objectPosition;
        }

        //Start Player Movement
        if (speed == 0 && UnityEngine.InputSystem.Keyboard.current.wKey.wasPressedThisFrame)
        {
            speed = 6;
        }
        else if (speed == 0 && UnityEngine.InputSystem.Keyboard.current.aKey.wasPressedThisFrame)
        {
            speed = 6;
        }
        else if (speed == 0 && UnityEngine.InputSystem.Keyboard.current.sKey.wasPressedThisFrame)
        {
            speed = 6;
        }
        else if (speed == 0 && UnityEngine.InputSystem.Keyboard.current.dKey.wasPressedThisFrame)
        {
            speed = 6;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        
        Gizmos.DrawWireCube(transform.position, rectSize);
    }
}
