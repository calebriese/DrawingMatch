using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class imageFromStart : MonoBehaviour
{
    public randomImage script;
    GameObject image;
    // Start is called before the first frame update
    void Start()
    {
        GameObject thisGuy = GameObject.Find("randomImageObject");
        script = thisGuy.GetComponent<randomImage>();

        Vector2 position = new Vector2(-7f, -3f);
        Quaternion noRote = new Quaternion(0, 0, 0, 0);
        int num = script.rando;
        image = Instantiate(script.images[num], position, noRote);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
