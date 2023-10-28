using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteInfo : MonoBehaviour
{
    [SerializeField]
    Vector2 rectSize;
    //[SerializeField]
    //Vector2 rectSize2;
    //
    //[SerializeField]
    //List<Vector2> rectSize;

    [SerializeField]
    new SpriteRenderer renderer;

    [SerializeField]
    public bool isColliding = false;

    public Vector2 RectMin
    {
        get
        {
            float minX = transform.position.x - (rectSize.x / 2);
            float minY = transform.position.y - (rectSize.y / 2);
            return new Vector2(minX, minY);
        }
    }

    public Vector2 RectMax
    {
        get
        {
            float maxX = transform.position.x + (rectSize.x / 2);
            float maxY = transform.position.y + (rectSize.y / 2);
            return new Vector2(maxX, maxY);
        }
    }



    // Update is called once per frame
    void Update()
    {
        if (isColliding)
        {
            //draw red
            renderer.color = Color.red;
        }
        else
        {
            //draw white
            renderer.color = Color.white;
        }
    }

    /// <summary>
    /// Wireframe to help see when debugging
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        
        Gizmos.DrawWireCube(transform.position, rectSize);
    }
}