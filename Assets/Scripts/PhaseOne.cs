using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class PhaseOne : MonoBehaviour
{


    public void NextPhase()
    {
        SceneManager.LoadScene(4);
    }

    public void EndGame()
    {
        SceneManager.LoadScene(6);
    }
}
