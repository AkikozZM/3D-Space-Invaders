using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileScript : MonoBehaviour
{
    public float missileSpeed;
    void Start()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, -missileSpeed * 25f, 0));
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            ObstacleScript obs = collision.gameObject.GetComponent<ObstacleScript>();
            obs.Die();
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject player = GameObject.Find("Ship").gameObject;
            player.GetComponent<Ship>().playerGetHurt();
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }

    }

}
