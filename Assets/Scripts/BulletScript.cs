using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float attkSpeed;

    void Start()
    {
        GetComponent<Rigidbody>().drag = 0;
        GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, attkSpeed * 50f));
    }
    private void OnCollisionEnter(Collision collision)
    {
        Collider collider = collision.collider;
        if (collider.CompareTag("Obstacle"))
        {
            ObstacleScript obs = collider.GetComponent<ObstacleScript>();
            obs.Die();
            Destroy(gameObject);
        }
        if (collider.CompareTag("Invader"))
        {
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary"))
        {
            Destroy(gameObject);
        }
    }
}
