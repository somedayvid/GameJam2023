using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionManager : MonoBehaviour
{
    HealthManager healthManager;
    ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        healthManager = GetComponent<HealthManager>();
        scoreManager = GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        TagCollision();
    }

    public void TagCollision()
    {
        GameObject[] shots = GameObject.FindGameObjectsWithTag("Shot");
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] explosions = GameObject.FindGameObjectsWithTag("AOE");
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

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

            foreach (GameObject explosion in explosions)
            {
                SpriteInfo enemySprite = enemy.GetComponent<SpriteInfo>();
                SpriteInfo explosionSprite = explosion.GetComponent<SpriteInfo>();

                if (CheckCollision(enemySprite, explosionSprite))
                {
                    // Destroy both enemy
                    Destroy(enemy);

                    //Change number to set score gain
                    scoreManager.EnemyKilled(10);
                }
            }

            foreach (GameObject player in players)
            {
                SpriteInfo enemySprite = enemy.GetComponent<SpriteInfo>();
                SpriteInfo playerSprite = player.GetComponent<SpriteInfo>();

                if (CheckCollision(enemySprite, playerSprite))
                {
                    // Destroy both enemy and bullet upon collision
                    Destroy(enemy);

                    //Change number to set score gain
                    //Reenable if you want player to gain a score on collision
                    //scoreManager.EnemyKilled(10);

                    healthManager.DamagePlayer(10f, .5f);
                }
            }
        }
       
    }

    /// <summary>
    /// Uses AABB collision to check if two sprites are colliding
    /// </summary>
    /// <param name="player">The first sprite</param>
    /// <param name="enemy">The second sprite</param>
    /// <returns>True if they collide</returns>
    public bool CheckCollision(SpriteInfo player, SpriteInfo enemy)
    {
        if (enemy.RectMin.x < player.RectMax.x && enemy.RectMax.x > player.RectMin.x &&
            enemy.RectMin.y < player.RectMax.y && enemy.RectMax.y > player.RectMin.y)
        {
            return true;
        }
        return false;
    }
}
