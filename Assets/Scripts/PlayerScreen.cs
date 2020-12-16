using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScreen : MonoBehaviour
{
    public void PlayerOne()
    {
        SceneManager.LoadScene(2);
    }
    public void PlayerTwo()
    {
        SceneManager.LoadScene(3);
    }
}
