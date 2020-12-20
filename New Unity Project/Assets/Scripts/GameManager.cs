using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject controlMenu;
    public Text levelText;
    static public int levelProgress = 1;
    public int levelset;
    public bool isPaused = false;

    private void Update()
    {
        //if escape is pressed it only pauses the menu
        if (Input.GetKeyDown(KeyCode.Escape)) { isPaused = false; togglePause(); }

        //constantly display the current level Progress
        levelText.GetComponent<Text>().text = "Level: " + levelProgress;
    }
    //returns the current progress
    public int getLevelProgress() { return levelProgress; }

    //returns whether the level is paused or not
    public bool getIsPaused() { return isPaused; }

    //increses the counter for the next level to unlock
    public void nextLevel() { levelProgress = levelset; }

    //reloads the lobby scene
    public void lobbyReturn() { SceneManager.LoadScene("Lobby"); }

    //increases counter for next level unlock and then reloads the lobby scene
    public void skipLevel() { nextLevel();  lobbyReturn(); }

    //go to GitHub Repo
    public void goToSource() { Application.OpenURL("https://github.com/TiernanH/Unity-College-Project--complete-"); }

    // controls menu open
    public void openControls() { controlMenu.SetActive(true); pauseMenu.SetActive(false); }
    //controls menu close
    public void closeControls() { controlMenu.SetActive(false); pauseMenu.SetActive(true); }

    //toggles the game pause, cursor state and menu
    public void togglePause()
    {
        if (isPaused == true) {
            isPaused = false;
            Cursor.lockState = CursorLockMode.Locked;
            pauseMenu.SetActive(false);
        }
        else if (isPaused == false) { 
            isPaused = true;
            Cursor.lockState = CursorLockMode.None;
            pauseMenu.SetActive(true);
        }
    }
}
