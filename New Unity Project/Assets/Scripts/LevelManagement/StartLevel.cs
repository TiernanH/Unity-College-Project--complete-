using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLevel : MonoBehaviour
{
    ///////////////////////////////////////
    //redunant script, might change later//
    ///////////////////////////////////////

    //take in absolute value
    [SerializeField] private string loadLevel;

    public void OnTriggerEnter(Collider other)
    {
        //if player collides
        if (other.CompareTag("Player"))
        {
            //load given level
            SceneManager.LoadScene(loadLevel);
        }
    }
}
