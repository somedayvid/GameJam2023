using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManagement : MonoBehaviour
{
    [SerializeField]
    SpriteInfo heart;
    [SerializeField]
    List<SpriteInfo> heartsSpawned = new List<SpriteInfo>();
    private int totalHearts = 5;
    private Vector3 heartLocation;



    private float screenHeight;
    private float screenWidth;

    // Start is called before the first frame update
    void Start()
    {
        screenHeight = 2f * Camera.main.orthographicSize;
        screenWidth = screenHeight * Camera.main.aspect;

        //Starting Location
        heartLocation = new Vector3((0 - screenWidth / 2 + .5f), (0 + screenHeight / 2 - .5f), 0);
        //Spawn All Hearts
        for (int i = 0; i < totalHearts; i++)
        {
            heartsSpawned.Add(Instantiate(heart, heartLocation, Quaternion.identity));

            heartLocation.x += .5f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
