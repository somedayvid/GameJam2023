using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    private float round;

    public float Round { get { return round; } }

    // Start is called before the first frame update
    void Start()
    {
        round = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextRound()
    {
        round++;
        // Spawn enemies / other round related stuff
    }
}
