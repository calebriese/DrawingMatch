using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class PhaseTwo : MonoBehaviour
{
    public void NextPhase()
    {
        SceneManager.LoadScene(5);
    }

    public void EndGame()
    {
        SceneManager.LoadScene(6);
    }

    
}
