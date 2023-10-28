using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    [SerializeField] List<SpriteInfo> enemySprites = new List<SpriteInfo>();

    // Start is called before the first frame update
    void Start()
    {
        
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
        }
    }

    public bool CheckCollision(SpriteInfo player, SpriteInfo enemy)
    {
        if (enemy.RectMin.x < player.RectMax.x && enemy.RectMax.x > player.RectMin.x &&
            enemy.RectMin.y < player.RectMax.y && enemy.RectMax.y > player.RectMin.y)
        {
            Debug.Log("Collision detected");
            return true;
        }
        return false;
    }
}
