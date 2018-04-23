using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class gameManager : MonoBehaviour {

    static bool isPlayerDead;
    public GameObject loseScreen;
    GameObject[] gameObjects;

    // Use this for initialization
    void Start () {
        isPlayerDead = false;
        loseScreen.SetActive(false);
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
	}

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public static void playerDead()
    {
        isPlayerDead = true;
    }

    public void Home()
    {
        SceneManager.LoadScene(0);
    }
}
