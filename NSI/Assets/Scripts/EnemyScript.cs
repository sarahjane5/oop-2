using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    public int speed = 2;

    // Use this for initialization
    void Start () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
    }
	
	// Update is called once per frame
	void Update () {
        //This checks if the enemy has reached the edge of the screen and if it has then it negates its speed to make it change direction and drops it down one level on the x axis
        if (transform.position.x >= 6)
        {
            transform.position = new Vector2(transform.position.x - 1, transform.position.y - 1);
            speed = -speed;
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
        }
        else if (transform.position.x <= -6)
        {
            transform.position = new Vector2(transform.position.x + 1, transform.position.y - 1);
            speed = -speed;
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
        }
    }
    void OnBecameVisible()
    {
        //Only allows the enemy to shoot once its onscreen by enabling it when it enters the camera
        GetComponent<EnemyShoot>().enabled = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //if enemy collides with player then it destroys the player and runs the playerDead function from the gameManager script.
        if (other.tag == "Player")
        {
            Destroy(other.gameObject);
            gameManager.playerDead();
        }
    }
}