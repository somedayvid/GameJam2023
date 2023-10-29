using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public NarwhalMovement narwhal;
    public EnemyMovement bear;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void Spawn()
    {
        narwhal.Spawn();
        bear.Spawn();
    }
}
