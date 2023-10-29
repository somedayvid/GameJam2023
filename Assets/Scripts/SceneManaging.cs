using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManaging : MonoBehaviour
{
    private HealthManagement healthManagement;

    void Start()
    {
        healthManagement = GetComponent<HealthManagement>(); 
    }
    void Update()
    {
        //if (healthManagement.isDead)
        //{
        //    SceneManager.LoadScene("GameOver");
        //}
    }

    /// <summary>
    /// Load the instructions scene
    /// </summary>
    public void LoadInstructions()
    {
        try {
            SceneManager.LoadScene("Instructions");
        }
        catch (System.Exception error) {
            throw new System.Exception(error.Message);
        }
    }

    /// <summary>
    /// Load the main game scene
    /// </summary>
    public void LoadGame()
    {
        try {
            SceneManager.LoadScene("Main");
        }
        catch (System.Exception error) {
            throw new System.Exception(error.Message);
        }
    }

    /// <summary>
    /// Load the game over scene
    /// </summary>
    public void LoadGameOver()
    {
        try {
            if (healthManagement.Died)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
        catch (System.Exception error) {
            throw new System.Exception(error.Message);
        }
    }

    /// <summary>
    /// Load the home scene
    /// </summary>
    public void LoadHome()
    {
        try {
            SceneManager.LoadScene("Home");
        }
        catch (System.Exception error) {
            throw new System.Exception(error.Message);
        }
    }

    /// <summary>
    /// Quit game
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
}
