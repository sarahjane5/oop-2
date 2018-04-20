using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class gameManager : MonoBehaviour {

    static bool isPlayerDead;
    public GameObject loseScreen;

	// Use this for initialization
	void Start () {
        isPlayerDead = false;
        loseScreen.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (isPlayerDead)
        {
            loseScreen.SetActive(true);
        }
	}

    public void restart()
    {
        SceneManager.LoadScene(0);
    }

    public static void playerDead()
    {
        isPlayerDead = true;
    }
}
