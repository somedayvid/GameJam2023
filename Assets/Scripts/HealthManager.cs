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
    void Start()
    {
        health = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        // Temporary code to test heal
        if (UnityEngine.InputSystem.Keyboard.current.pKey.wasPressedThisFrame)
        {
            Debug.Log("P was pressed");
            HealPlayer(10f);
        }
    }

    /// <summary>
    /// Damages the player by the given amount
    /// </summary>
    /// <param name="damage"></param>
    public void DamagePlayer(float damage, float duration)
    {
        StartCoroutine(HealthOverTime(damage, duration));
        health = Mathf.Clamp(health, 0, 100);
    }

    /// <summary>
    /// Heals the player by the given amount
    /// </summary>
    /// <param name="heal"></param>
    public void HealPlayer(float heal)
    {
/*        health += heal;
        health = Mathf.Clamp(health, 0, 100);

        healthBar.fillAmount = health / 100f;*/
        StartCoroutine(HealthOverTime(heal, 1f));
        health = Mathf.Clamp(health, 0, 100);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="damage"></param>
    /// <param name="duration"></param>
    /// <returns></returns>
    IEnumerator HealthOverTime(float damage, float duration)
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
}
