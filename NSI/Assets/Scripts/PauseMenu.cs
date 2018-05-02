 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool GamePaused = false;

    public GameObject PauseMenuUI;


    void Start()
    {
        GamePaused = false;
    }
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
	}

     public void Resume()
    {

        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }

    void Pause()
    {
        //Turns on the pause menu, stops time and sets the GamePaused boolean to be true
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }

    public void LoadMenu()
    {
        //loads the menu scene
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        //When inside unity and you quit it sends a message to the console alerting that the game was quit, when in an application it closes the application window
        Debug.Log("Quit the game!");
        Application.Quit();
    }
}