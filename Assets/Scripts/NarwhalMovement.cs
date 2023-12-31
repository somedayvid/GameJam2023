using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class NarwhalMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 direction;
    [SerializeField]
    private float velocity;
    private SpriteRenderer spriteRenderer;
        
    private Camera cam;
    private float camHeight;
    private float camWidth;
    private float camRight;
    private float camLeft;
    private float camTop;
    private float camBottom;
    void Start()
    {
        cam = Camera.main;
        camHeight = 2.0f * cam.orthographicSize;
        camWidth = camHeight * cam.aspect;

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
        Die();
    }

    public void Spawn()
    {
        UpdateBounds();
        int spawnSide = Random.Range(0, 2);
        if (spawnSide == 0)
        {
            Instantiate(this, new Vector3(Random.Range(camTop + 5, camTop + 10), Random.Range(camBottom, camTop)), Quaternion.identity);
        }
        else if(spawnSide == 1)
        {
            Instantiate(this, new Vector3(Random.Range(camLeft - 5, camLeft - 10), Random.Range(camBottom, camTop)), Quaternion.identity);
        }
    }

    public void Die()
    {
        UpdateBounds();
        if(transform.position.x > camRight + 10 || transform.position.x < camLeft - 10)
        {
            Destroy(gameObject);
        }
    }

    private void UpdateBounds()
    {
        cam = Camera.main;
        camHeight = 2.0f * cam.orthographicSize;
        camWidth = camHeight * cam.aspect;

        camRight = camWidth/2;
        camLeft = -camWidth/2;
        camTop = camHeight/2;
        camBottom = -camHeight/2;
    }
}
