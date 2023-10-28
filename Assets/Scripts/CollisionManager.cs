using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    [SerializeField] SpriteInfo player;
    [SerializeField] bool isColliding;
    public bool Colliding { get { return isColliding; } }

    [SerializeField] SpriteInfo enemy;
    [SerializeField] List<SpriteInfo> enemySprites = new List<SpriteInfo>();
    private List<Vector2> enemyLocations = new List<Vector2>();
    private int enemiesKilled = 0;
    private int enemiesToKill;

    private int currentRound = 0;

    private float screenHeight;
    private float screenWidth;

    // Start is called before the first frame update
    void Start()
    {
        screenHeight = 2f * Camera.main.orthographicSize;
        screenWidth = screenHeight * Camera.main.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentRound == 0 || enemiesToKill == enemiesKilled)
        {
            currentRound++;

            SpawnEnemies();
        }

        for (int i = 0;i < enemySprites.Count;i++)
        {
            if (CheckCollision(player, enemySprites[i]))
            {
                isColliding = true;
                DestroyEnemy(i);
            }
            else
            {
                isColliding = false;
            }
        }

        //TagCollision();
    }

    
    public void TagCollision()
    {
        GameObject[] shots = GameObject.FindGameObjectsWithTag("Shot");
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] explosions = GameObject.FindGameObjectsWithTag("AOE");

        foreach (GameObject enemy in enemies)
        {
            foreach (GameObject shot in shots)
            {
                SpriteInfo enemySprite = enemy.GetComponent<SpriteInfo>();
                SpriteInfo shotSprite = shot.GetComponent<SpriteInfo>();

                if (CheckCollision(enemySprite, shotSprite))
                {
                    // Destroy both enemy and bullet upon collision
                    Destroy(enemy);
                    Destroy(shot);

                }
            }

            foreach(GameObject explosion in explosions)
            {
                SpriteInfo enemySprite = enemy.GetComponent<SpriteInfo>();
                SpriteInfo explosionSprite = explosion.GetComponent<SpriteInfo>();

                if (CheckCollision(enemySprite, explosionSprite))
                {
                    // Destroy both enemy and bullet upon collision
                    Destroy(enemy);

                }
            }


        }

        foreach (GameObject enemy in enemies)
        {
            SpriteInfo enemySprite = enemy.GetComponent<SpriteInfo>();

            if (CheckCollision(player, enemySprite))
            {
                Destroy(enemy);
                isColliding = true;
            }
            else
            {
                isColliding = false;
            }
        }
    }
    */

    public bool CheckCollision(SpriteInfo player, SpriteInfo enemy)
    {
        if (enemy.RectMin.x < player.RectMax.x &&
            enemy.RectMax.x > player.RectMin.x &&
            enemy.RectMin.y < player.RectMax.y &&
            enemy.RectMax.y > player.RectMin.y)
        {
            Debug.Log("Collision detected");
            return true;
        }
        return false;
    }

    public void SpawnEnemies()
    {
        enemiesKilled = 0;
        enemiesToKill = currentRound + 1;

        for (int j = 0; j < enemiesToKill; j++)
        {
            float newX = Random.Range(-screenWidth / 2, screenWidth / 2);
            float newY = Random.Range(-screenHeight / 2, screenHeight / 2);
            Vector2 newLoc = new Vector2(newX, newY);
            enemyLocations.Add(newLoc);
        }
        for (int i = 0; i < enemyLocations.Count; i++)
        {
                enemySprites.Add(Instantiate(enemy, enemyLocations[i], Quaternion.identity));
        }
    }

    public void DestroyEnemy(int i)
    {
        Destroy(enemySprites[i].gameObject);
        enemySprites.Remove(enemySprites[i]);
        enemiesKilled++;
    }
}
