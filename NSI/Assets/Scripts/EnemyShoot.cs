using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{

    public float timeBetweenShots;
    public float nextShot = 0;
    public GameObject bullet;

    // Use this for initialization
    void Start()
    {
        //Sets the nextShot variable to a random number between 1 and 6 & sets the time between shots to a random number between 2 and 6, at the start of the game
        nextShot = Random.Range(1, 6.0f);
        timeBetweenShots = Random.Range(2, 6f);
    }

    // Update is called once per frame
    void Update()
    {
        //When the time in seconds is greater than the nextShot value then the script spawns a fire prefab from the enemy position
        //Plays the "Shot" sound
        //Sets nextShot equal to time passed plus timeBetweenShots value
        if (Time.time > nextShot)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);

            FindObjectOfType<AudioManager>().Play("Shot");

            nextShot = Time.time + timeBetweenShots;
        }
    }
}