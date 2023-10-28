using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarwhalMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 direction;
    [SerializeField]
    private float velocity;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (transform.position.x < 0)
        {
            direction = Vector3.right;
            spriteRenderer.flipX = true;
        }
        else if (transform.position.x > 0)
        {
            direction = Vector3.left;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * velocity * Time.deltaTime;
    }
}
