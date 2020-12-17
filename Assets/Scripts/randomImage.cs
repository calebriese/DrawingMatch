using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomImage : MonoBehaviour
{
    GameObject [] images;
    GameObject newImage;
    public GameObject image1;
    public GameObject image2;
    public GameObject image3;
    public GameObject image4;
    public GameObject image5;
    public GameObject image6;
    public GameObject image7;
    public GameObject image8;
    public GameObject image9;
    // Start is called before the first frame update
    void Start()
    {
        images = new GameObject[9];

        images[0] = image1;
        images[1] = image2;
        images[2] = image3;
        images[3] = image4;
        images[4] = image5;
        images[5] = image6;
        images[6] = image7;
        images[7] = image8;
        images[8] = image9;

        int rando = Random.Range(0, 9);

        Vector2 position = new Vector2(0f, 1.33f);
        Quaternion noRote = new Quaternion(0, 0, 0, 0);
        newImage = Instantiate(images[rando], position, noRote);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
