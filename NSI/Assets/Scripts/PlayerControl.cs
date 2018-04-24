using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    private int moveSpeed = 6;
    public GameObject shot;
    public bool HasShot = false;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey("left"))
        {
            if (transform.position.x <= -6)
            {
                transform.Translate(0, 0, 0);
            }
            else
            {
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
                transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
            }
        }

        if (HasShot == false && Input.GetKeyDown("space"))
        {
            Instantiate(shot, transform.position, Quaternion.identity);
            HasShot = true;
        }
    }
}
