using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PhaseOne : MonoBehaviour
{
    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}

    public void NextPhase()
    {
        SceneManager.LoadScene(4);
    }

    public void EndGame()
    {
        SceneManager.LoadScene(6);
    }

}
