using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //Initializes the players speed, a shot game object and a bollean called HasShot
    private int moveSpeed = 6;
    public GameObject shot;
    public bool HasShot;

    // Use this for initialization
    void Start()
    {
        //At the start of the script the boolean is set to false 
        HasShot = false;
    }

    // Update is called once per frame
    void Update()
    {
        //This makes the player go left and right on key press
        if (Input.GetKey(KeyCode.A) || Input.GetKey("left"))
        {
            if (transform.position.x <= -6)
            {
                transform.Translate(0, 0, 0);
            }
            else
            {
                //Stops player going off the screen
                transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
            }

        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey("right"))
        {
            if (transform.position.x >= 6)
            {
                transform.Translate(0, 0, 0);
            }
            else
            {
                //Stops player going off the screen
                transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
            }
        }

        //Checks if the HasShot boolean is set to false and if the space bar has been pressed, if so it instantitates an egg from the players position then sets the HasShot boolean to true
        if (HasShot == false && Input.GetKeyDown("space"))
        {
            Instantiate(shot, transform.position, Quaternion.identity);
            HasShot = true;
        }
        else
        {
            //else gets out of if statement
            return;
        }
    }
}