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
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        //Instantiate(player);
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

    /*
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, player.transform.position);
    }
    */
}
