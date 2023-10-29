using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionManager : MonoBehaviour
{
    public GameObject attackContainer;

    public GameObject enemyContainer;

    public SpriteInfo player;

    public List<SpriteInfo> attackList = new List<SpriteInfo>();

    public List<SpriteInfo> enemyList = new List<SpriteInfo>();

    private List<SpriteInfo> markedToDestroy = new List<SpriteInfo>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EnemyCollision();
        //OutOfBounds();
        DestroyList();
    }

    public void EnemyCollision()
    {
        attackContainer.GetComponentsInChildren<SpriteInfo>(attackList);
        enemyContainer.GetComponentsInChildren<SpriteInfo>(enemyList);

        foreach (SpriteInfo enemy in enemyList)
        {
            foreach (SpriteInfo bullet in attackList)
            {
                if (bullet.CollideWith(enemy))
                {
                    markedToDestroy.Add(bullet);
                    markedToDestroy.Add(enemy);
                    break;
                }
            }
            if (enemy.CollideWith(player))
            {
                markedToDestroy.Add(enemy);
                //player takes damage code here
                break;
            }
        }
    }

    //possibly not needed
    //public void OutOfBounds()
    //{   
    //    foreach (SpriteInfo bullet in attackList)
    //    {
    //        if (bullet.transform.position.y > 6)
    //        {
    //            markedToDestroy.Add(bullet);
    //        }
    //    }

    //    foreach (SpriteInfo enemy in enemyList)
    //    {
    //        if (enemy.transform.position.y < -6)
    //        {
    //            markedToDestroy.Add(enemy);
    //        }
    //    }
    //}

    /// <summary>
    /// Called at end of frame to destroy
    /// </summary>
    public void DestroyList()
    {
        foreach (SpriteInfo toDestroy in markedToDestroy)
        {
            if (attackList.Contains(toDestroy))
            {
                EraseAndDestroy(toDestroy, attackList);
            }
            else if (enemyList.Contains(toDestroy))
            {
                EraseAndDestroy(toDestroy, enemyList);
            }
        }
        markedToDestroy.Clear();
    }

    /// <summary>
    /// Called to destroy all colliding objects and remove them from their lists
    /// </summary>
    /// <param name="objectToDestroy"></param>
    /// <param name="listToDeleteFrom"></param>
    public void EraseAndDestroy(SpriteInfo objectToDestroy, List<SpriteInfo> listToDeleteFrom)
    {
        listToDeleteFrom.Remove(objectToDestroy);
        Destroy(objectToDestroy.gameObject);
    }

    /// <summary>
    /// Called for game reset states
    /// </summary>
    public void ClearAll()
    {
        foreach (SpriteInfo enemyShip in enemyList)
        {
            markedToDestroy.Add(enemyShip);
        }
        foreach (SpriteInfo playerBullet in attackList)
        {
            markedToDestroy.Add(playerBullet);
        }
    }
}
