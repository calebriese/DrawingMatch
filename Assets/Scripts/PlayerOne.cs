using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class PlayerOne : MonoBehaviour
{
    public void EndGame()
    {
        SceneManager.LoadScene(6);
    }
}
