using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMesh textPrefab;
    private TextMesh text;
    private float score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        text = Instantiate(textPrefab, textPrefab.transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Score: " + score;
    }

    public void EnemyKilled(float points)
    {
        score += points;
    }
}
