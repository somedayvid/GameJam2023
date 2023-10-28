using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionAnimate : MonoBehaviour
{
    public Sprite[] frames;
    public float frameDuration = 1f;

    private SpriteRenderer spriteRenderer;
    private int currentFrame = 0;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = frames[currentFrame];
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= frameDuration)
        {
            timer = 0f;

            if (currentFrame < frames.Length - 1)
            {
                currentFrame++;
                spriteRenderer.sprite = frames[currentFrame];
            }
            else
            {
                
            }
        }
    }
}
