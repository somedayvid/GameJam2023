using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteInfo : MonoBehaviour
{
    [SerializeField] new SpriteRenderer renderer;
    [SerializeField] Vector2 rectSize;

    public Vector2 RectMin
    {
        get
        {
            return new Vector2(
                transform.position.x - (rectSize.x / 2f),
                transform.position.y - (rectSize.y / 2f));
        }
    }

    public Vector2 RectMax
    {
        get
        {
            return new Vector2(
                transform.position.x + (rectSize.x / 2f),
                transform.position.y + (rectSize.y / 2f));
        }
    }

    private void Start()
    {
        rectSize = new Vector2(renderer.bounds.size.x, renderer.bounds.size.y);
    }

    // Update is called once per frame
    void Update()
    {

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