using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeLevel : MonoBehaviour
{
    //take in absolute value for the level we want to load
    [SerializeField] private string loadLevel;
    //pull the GameManager
    private GameManager gameManager;
    //image for fade in 
    public Image fade;

    private void Start()
    {
        //set the gameManager to actual
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        fade.canvasRenderer.SetAlpha(0.0f);
    }
    IEnumerator WaitBeforeNext(float seconds)
    {
        //start crossfade
        fade.CrossFadeAlpha(1.0f, 3, false);
        //wait for seconds
        yield return new WaitForSeconds(seconds);
        //load given level
        SceneManager.LoadScene(loadLevel);
        //increase level counter
        gameManager.nextLevel();
    }

    //when the player colides with trigger
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            StartCoroutine(WaitBeforeNext(4f));
        }
    }
}
