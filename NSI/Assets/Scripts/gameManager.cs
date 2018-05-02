using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class gameManager : MonoBehaviour {

    static bool isPlayerDead;
    static bool hasWon;
    public GameObject loseScreen;
    public GameObject winScreen;
    GameObject[] gameObjects;

    // Use this for initialization
    void Start() {
        isPlayerDead = false;
        hasWon = false;
        loseScreen.SetActive(false);
        winScreen.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        //Checks if isPlayerDead is true then finds all the objects with enemy and shot tags and destroys them 
        //Activates Lose Screen and sets the score variable inside the score script to 0
        if (isPlayerDead)
        {
            gameObjects = GameObject.FindGameObjectsWithTag("Enemy");

            for (var i = 0; i < gameObjects.Length; i++)
            {
                Destroy(gameObjects[i]);
            }

            gameObjects = GameObject.FindGameObjectsWithTag("shot");

            for (var i = 0; i < gameObjects.Length; i++)
            {
                Destroy(gameObjects[i]);
            }

            loseScreen.SetActive(true);
            Score.score = 0;
        }

        //Checks if HasWon is true then finds all the objects with enemy and shot tags and destroys them 
        //Activates Win Screen and sets the score variable inside the score script to 0
        else if (hasWon)
        {
            gameObjects = GameObject.FindGameObjectsWithTag("Enemy");

            for (var i = 0; i < gameObjects.Length; i++)
            {
                Destroy(gameObjects[i]);
            }

            gameObjects = GameObject.FindGameObjectsWithTag("shot");

            for (var i = 0; i < gameObjects.Length; i++)
            {
                Destroy(gameObjects[i]);
            }

            winScreen.SetActive(true);
            Score.score = 0;
        }

        //Checks if score is equal to 25 and if true it calls the winGame function
        if (Score.score == 25)
        {
            winGame();
        }
	}

    public void Restart()
    {
        //Sets the score to 0 and loads the first scene in the build index
        Score.score = 0;
        SceneManager.LoadScene(1);

    }

    public void Continue()
    {
        //Sets the score to 0 and deactivates the win screen then loads the following scene
        Score.score = 0;
        winScreen.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public static void playerDead()
    {
        //Sets the isPlayerDead boolean to true
        isPlayerDead = true;
    }

    public void Home()
    {
        //Loads the main menu (first scene)
        SceneManager.LoadScene(0);
    }

    public static void winGame()
    {
        //Sets the hasWon boolean to true
        hasWon = true;
    }
 }