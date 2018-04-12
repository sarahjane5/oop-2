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
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == target)
        {
            Destroy(other.gameObject);
            GameObject fire = (GameObject)Instantiate(explosion,other.gameObject.transform.position,Quaternion.identity);
            Destroy(fire,1.0f);
            Score.updateScore();
            Destroy(gameObject);
        }
    }
}
