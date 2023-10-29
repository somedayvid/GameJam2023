using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshPro textPrefab;
    private float score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        textPrefab = Instantiate(textPrefab, textPrefab.transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        textPrefab.sortingOrder = 10;
        textPrefab.text = "Score: " + score;
    }

    public void EnemyKilled(float points)
    {
        score += points;
    }
}
