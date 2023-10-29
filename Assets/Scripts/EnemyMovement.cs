using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private GameObject player;
    private Vector3 direction;
    [SerializeField]
    private float velocity;
    public Animator animator;

    Camera cam;
    float camHeight;
    float camWidth;
    float camRight;
    float camLeft;
    float camTop;
    float camBottom;
    void Start()
    {
        cam = Camera.main;
        camHeight = 2.0f * cam.orthographicSize;
        camWidth = camHeight * cam.aspect;

        camRight = camWidth/2;
        camLeft = -camWidth/2;
        camTop = camHeight/2;
        camBottom = -camHeight/2;

        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 thing = player.transform.position - transform.position;
        direction = thing.normalized;
        transform.position += direction * velocity * Time.deltaTime;

    }

    private void AnimateMove()
    {

    }

    public void Spawn()
    {
        int spawnPoint = Random.Range(0, 4);
        switch (spawnPoint)
        {
            case 0:
                Instantiate(this, new Vector3(Random.Range(camLeft, camRight), Random.Range(camTop, camTop + 5), 0), Quaternion.identity);
                break;
            case 1:
                Instantiate(this, new Vector3(Random.Range(camRight, camRight + 5), Random.Range(camBottom, camTop), 0), Quaternion.identity);
                break;
            case 2:
                Instantiate(this, new Vector3(Random.Range(camLeft, camRight), Random.Range(camBottom - 5, camBottom), 0), Quaternion.identity);
                break;
            case 3:
                Instantiate(this, new Vector3(Random.Range(camRight - 5, camRight), Random.Range(camBottom, camTop), 0), Quaternion.identity);
                break;
        }
    }

    /*
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, player.transform.position);
    }
    */
}
