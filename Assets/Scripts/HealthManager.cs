using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [SerializeField] Image healthBar;
    private float health = 100f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (UnityEngine.InputSystem.Keyboard.current.oKey.wasPressedThisFrame)
        {
            DamagePlayer(5f);
        }
        if (UnityEngine.InputSystem.Keyboard.current.pKey.wasPressedThisFrame)
        {
            HealPlayer(5f);
        }
    }

    /// <summary>
    /// Damages the player by the given amount
    /// </summary>
    /// <param name="damage"></param>
    public void DamagePlayer(float damage)
    {
        health -= damage;
        healthBar.fillAmount = health / 100f;
    }

    /// <summary>
    /// Heals the player by the given amount
    /// </summary>
    /// <param name="heal"></param>
    public void HealPlayer(float heal)
    {
        health += heal;
        health = Mathf.Clamp(health, 0, 100);

        healthBar.fillAmount = health / 100f;
    }
}
