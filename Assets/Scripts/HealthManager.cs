using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [SerializeField] Image healthBar;
    private float health;

    // Start is called before the first frame update
    void Start() { health = 100f; }

    // Update is called once per frame
    void Update()
    {
        // Temporary code to test heal
        // Delete the entire update function when done
        if (UnityEngine.InputSystem.Keyboard.current.pKey.wasPressedThisFrame)
        {
            Debug.Log("P was pressed");
            HealPlayer(10f, 1f);
        }
    }

    /// <summary>
    /// Damages the player by the given amount
    /// </summary>
    /// <param name="damage">The amount to deal</param>
    /// <param name="duration">The time</param>
    public void DamagePlayer(float damage, float duration)
    {
        StartCoroutine(DamageHealthOverTime(damage, duration));
        health = Mathf.Clamp(health, 0, 100);
    }

    /// <summary>
    /// Heals the player by the given amount
    /// </summary>
    /// <param name="heal">The amount to heal</param>
    /// <param name="duration">The time</param>
    public void HealPlayer(float heal, float duration)
    {
        StartCoroutine(HealHealthOverTime(heal, duration));
        health = Mathf.Clamp(health, 0, 100);
    }

    /// <summary>
    /// Decreases the health of the player by the given amount over the given duration
    /// </summary>
    /// <param name="damage">The amount to be damaged</param>
    /// <param name="duration">The duration of animation</param>
    /// <returns>Nothing but the completed action</returns>
    IEnumerator DamageHealthOverTime(float damage, float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            health -= damage * Time.deltaTime / duration;
            healthBar.fillAmount = health / 100f;

            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    /// <summary>
    /// Increases the health of the player by the given amount over the given duration
    /// </summary>
    /// <param name="healAmount">The amount to be healed</param>
    /// <param name="duration">The duration of animation</param>
    /// <returns>Nothing but the completed action</returns>
    IEnumerator HealHealthOverTime(float healAmount, float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            health += healAmount * Time.deltaTime / duration;
            health = Mathf.Clamp(health, 0f, 100f);
            healthBar.fillAmount = health / 100f;

            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
