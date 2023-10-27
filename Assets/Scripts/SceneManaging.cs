using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManaging : MonoBehaviour
{
    public void ToInstructions()
    {
        SceneManager.LoadScene("Instructions");
    }
    public void StartgGame()
    {
        SceneManager.LoadScene("Main");
    }
    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
    public void GoHome()
    {
        SceneManager.LoadScene("Home");
    }
}
