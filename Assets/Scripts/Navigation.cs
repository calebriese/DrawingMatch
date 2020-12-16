using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Navigation : MonoBehaviour
{
    public void ButtonStart()
    {
        SceneManager.LoadScene(1);
    }

    public void NextPhase()
    {
        if (SceneManager.GetActiveScene().buildIndex != 2) //if your not P1 then advance scene to the next phase
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void EndGame()
    {
        SceneManager.LoadScene(6);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void PlayerOne()
    {
        SceneManager.LoadScene(2);
    }
    public void PlayerTwo()
    {
        SceneManager.LoadScene(3);
    }
}
