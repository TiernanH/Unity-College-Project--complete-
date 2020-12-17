using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrapReset : MonoBehaviour
{
    /////////////////////////////////////////
    // same as startLevel but with a method//
    /////////////////////////////////////////
    

    [SerializeField] private string loadLevel;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            reloadScene();
        }
    }

    public void reloadScene()
    {
        SceneManager.LoadScene(loadLevel);
    }
}



