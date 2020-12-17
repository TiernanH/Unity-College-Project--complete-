using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelChecker : MonoBehaviour
{
    //pull GameManager
    private GameManager gameManager;
    //make array of level doors
    public GameObject[] levels;
    private int progress;

    void Start()
    { 
        //set gameManager to object actual
        gameManager = GameObject.FindObjectOfType<GameManager>();
        //pull the current level progress
        progress = gameManager.getLevelProgress();

        //loop through the door array up to current progress
        for(int i = 0; i < progress; i++)
        {
            //open each of those doors
            levels[i].SetActive(false);
        }

    }
}
