﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotControl : MonoBehaviour
{

    public int speed = 3;
    public int damage;
    public string target;
    public GameObject explosion;


    // Use this for initialization
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
    }

    void Update()
    {
        if ((transform.position.y >= 4.8 && transform.position.y <= 5.2)&& tag == "playershot")
        {
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);

        /*FindObjectOfType<PlayerControl>().HasShot = false;*/
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == target)
        {
            if (other.tag == "Player")
            {
                gameManager.playerDead();
            }
            else
            {
                Score.updateScore();
            }

            FindObjectOfType<AudioManager>().Play("EnemyDeath");
            Destroy(other.gameObject);
            GameObject fire = (GameObject)Instantiate(explosion,other.gameObject.transform.position,Quaternion.identity);
            Destroy(fire,1.0f);
            Destroy(gameObject);
        }
    }
}
