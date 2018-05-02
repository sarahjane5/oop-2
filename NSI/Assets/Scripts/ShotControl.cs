using System.Collections;
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
        //Sets the respective bullet moving
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
    }

    void Update()
    {
        //Destroys objects with the playershot tag if they fall between 4.8 and 5.2 on the Y axis
        if ((transform.position.y >= 4.8 && transform.position.y <= 5.2) && tag == "playershot")
        {
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        //Destroys any bullets that go offscreen
        Destroy(gameObject);

        //if the bullet has the playershot tag it sets the HasShot variable from the PlayerControl script to false to allow the player to shoot again
        if (gameObject.tag == "playershot")
        {
            FindObjectOfType<PlayerControl>().HasShot = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Checks if the tag of the object colliding with the game object is the destined target.
        if (other.tag == target)
        {
            //If the destined target has the Player tag then call the playerDead function in the gameManager script
            if (other.tag == "Player")
            {
                gameManager.playerDead();
            }
            else
            {
                //If the tag is not Player then call the updateScore function in the Score script 
                //Sets the HasShot variable from the PlayerControl script to false to allow the player to shoot again
                Score.updateScore();
                FindObjectOfType<PlayerControl>().HasShot = false;
            }
            //Plays the EnemyDeath sound and destroys the target gameObject, spawns the explosion animation at the position the gameObject was destroyed at and then destroys this animation also
            FindObjectOfType<AudioManager>().Play("EnemyDeath");
            Destroy(other.gameObject);
            GameObject fire = (GameObject)Instantiate(explosion, other.gameObject.transform.position, Quaternion.identity);
            Destroy(fire, 1.0f);
            Destroy(gameObject);
        }
    }
}