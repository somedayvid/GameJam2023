using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteInfo : MonoBehaviour
{
    // Variable field
    [SerializeField] new SpriteRenderer renderer;
    [SerializeField] Vector2 rectSize;

    /// <summary>
    /// Get property for minimum x and y values of the sprite
    /// </summary>
    public Vector2 RectMin
    {
        get
        {
            return new Vector2(
                transform.position.x - (rectSize.x / 2f),
                transform.position.y - (rectSize.y / 2f));
        }
    }

    /// <summary>
    /// Get property for maximum x and y values of the sprite
    /// </summary>
    public Vector2 RectMax
    {
        get
        {
            return new Vector2(
                transform.position.x + (rectSize.x / 2f),
                transform.position.y + (rectSize.y / 2f));
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        rectSize = new Vector2(renderer.bounds.size.x, renderer.bounds.size.y);
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