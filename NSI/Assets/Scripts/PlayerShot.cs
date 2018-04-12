using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour {
    public int speed = 5;
    public int damage;
    
    void Start () {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
        }

        void OnBecameInvisible () {
            Destroy(gameObject);
        }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}