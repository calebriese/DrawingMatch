using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playertwotext : MonoBehaviour
{
public string theText;
public GameObject inputfield;
public GameObject textDisplay;

public void TextEnter()
{
const int MAX_Len=21;
string theText = string.Empty;
theText=inputfield.GetComponent<Text>().text;
if(theText.Length > MAX_Len)
    theText = theText.Substring(0,MAX_Len -1);
textDisplay.GetComponent<Text>().text = "Player 2 said: " + theText;
}
}
