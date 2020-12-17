using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelPrompt : MonoBehaviour
{
    //this is for displaying text when closew to the level doors

    //input text
    public string displayText;
    //grab the display
    public Text text;

    //on enter display level text
    private void OnTriggerEnter(Collider other) { text.GetComponent<Text>().text = displayText; }
    //on exit clear the text
    private void OnTriggerExit(Collider other) { text.GetComponent<Text>().text = ""; }
}
