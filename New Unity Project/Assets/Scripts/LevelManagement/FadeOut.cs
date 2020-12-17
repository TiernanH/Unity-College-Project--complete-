using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    public Image fade1;
    public GameObject welcomeText;
    // Start is called before the first frame update
    void Start()
    {
        fade1.canvasRenderer.SetAlpha(1.0f);
        fadeOut();
    }
    
    IEnumerator WaitBeforeClose(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        welcomeText.SetActive(false);
    }
    void fadeOut()
    {
        fade1.CrossFadeAlpha(0.0f,4,false);
        StartCoroutine(WaitBeforeClose(5));
    }
}
