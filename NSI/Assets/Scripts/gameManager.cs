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
        loseScreen.SetActive(false);
        winScreen.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
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

        if (hasWon)
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

        if (Score.score == 1)
        {
            winGame();
        }
	}

    public void Restart()
    {
        //SceneManager.LoadScene(1);
        Score.score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);

    }

    public void Continue()
    {
        Score.score = 0;
        winScreen.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public static void playerDead()
    {
        isPlayerDead = true;
    }

    public void Home()
    {
        SceneManager.LoadScene(0);
    }

    public static void winGame()
    {
        hasWon = true;
    }
 }
