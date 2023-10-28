using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    Vector3 objectPosition = Vector3.zero;
    Vector3 direction = Vector3.zero;
    Vector3 velocity = Vector3.zero;

    float screenHeight;
    float screenWidth;

    [SerializeField]
    float speed = 0;

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
        if (transform.position.x < -(screenWidth / 2))
        {
            //Clampa the speed
        }
        else if (transform.position.x > (screenWidth / 2))
        {
            //HELPPPP
        }
        //Warp Around Screen Y
        if (transform.position.y < -(screenHeight / 2))
        {
           //Please Clamp speed here
        }
        else if (transform.position.y > screenHeight / 2)
        {
            //Jason Help
        }
    }
}
