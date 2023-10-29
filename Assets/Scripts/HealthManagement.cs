using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManagement : MonoBehaviour
{
    [SerializeField]
    SpriteInfo heart;
    [SerializeField]
    List<SpriteInfo> heartsSpawned = new List<SpriteInfo>();
    private int startingHearts = 5;
    private Vector3 heartLocation;
    public bool isDead;
    public bool Died { get { return isDead; } }

    private CollisionManager collisionManager;

    private float screenHeight;
    private float screenWidth;

    // Start is called before the first frame update
    void Start()
    {
        screenHeight = 2f * Camera.main.orthographicSize;
        screenWidth = screenHeight * Camera.main.aspect;

        collisionManager = GetComponent<CollisionManager>();

        //Starting Location
        heartLocation = new Vector3((0 - screenWidth / 2 + .5f), (0 + screenHeight / 2 - .5f), 0);
        //Spawn All Hearts
        for (int i = 0; i < startingHearts; i++)
        {
            heartsSpawned.Add(Instantiate(heart, heartLocation, Quaternion.identity));

            heartLocation.x += 1f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = heartsSpawned.Count - 1;i >= 0;i--)
        {
            //if (collisionManager.Colliding)
            //{
            //    DestroyHeart(i);
            //}
        }

        if (heartsSpawned.Count == 0)
        {
            isDead = true;
        }
        else
        {
            isDead = false;
        }
    }

    public void DestroyHeart(int i)
    {
        Destroy(heartsSpawned[i].gameObject);
        heartsSpawned.Remove(heartsSpawned[i]);
        startingHearts--;
    }
}
