using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{

    public float timeBetweenShots;
    public float nextShot = -1;
    public GameObject bullet;

    // Use this for initialization
    void Start()
    {
        nextShot = Random.Range(1, 6.0f);
        timeBetweenShots = Random.Range(2, 6f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextShot)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);

            FindObjectOfType<AudioManager>().Play("Shot");

            nextShot = Time.time + timeBetweenShots;
        }
    }
}
