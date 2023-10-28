using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Attack values and methods to be used in a manager
/// </summary>
public class Attacks : MonoBehaviour
{
    //Fields
    
    //Shot Fields - Linear shot moing towards mouse position
    [SerializeField]
    float shotSpeed = 1.0f;
    public GameObject shotPrefab;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FireShot(Vector2 targetPosition, float lifetime)
    {
        // Create a new shot object from the prefab
        GameObject shot = Instantiate(shotPrefab, transform.position, Quaternion.identity);

        // Calculate the direction towards the target position (mouse)
        Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;

        // Store the initial position of the shot for lifetime tracking
        Vector2 initialPosition = (Vector2)transform.position;

        // Destroy the shot object after its lifetime has ended
        Destroy(shot, lifetime);

        StartCoroutine(MoveShot(shot, direction, initialPosition, lifetime));
    }

    private IEnumerator MoveShot(GameObject shot, Vector2 direction, Vector2 initialPosition, float lifetime)
    {
        float elapsedTime = 0;

        while (elapsedTime < lifetime)
        {
            // Move the shot manually
            Vector2 newPosition = Vector2.Lerp(initialPosition, initialPosition + direction * shotSpeed, elapsedTime / lifetime);
            shot.transform.position = newPosition;

            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
