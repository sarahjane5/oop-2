﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public static int score;
    public Text scoreTxt;

    public static void updateScore()
    {
        score++;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
        scoreTxt.text = "Score: " + score;
	}
}