using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void Play ()
    {
        //Gets the current scene and increases it by 1
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        //When inside unity and you quit it sends a message to the console alerting that the game was quit, when in an application it closes the application window
        Debug.Log("You quit the game.");
        Application.Quit();
    }
}