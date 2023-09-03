using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public Vector3 forceVector;
    public float rotationSpeed;
    public float rotation;
    public GameObject bullet;
    public GameObject aim;

    void Start()
    {
        forceVector.x = 1.0f;
        rotationSpeed = 2.0f;
    }
    private void FixedUpdate()
    {
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            GetComponent<Rigidbody>().AddRelativeForce(forceVector);
        }
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            rotation += rotationSpeed;
            Quaternion rot = Quaternion.Euler(new Vector3(0, rotation, 0));
            GetComponent<Rigidbody>().MoveRotation(rot);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            rotation -= rotationSpeed;
            Quaternion rot = Quaternion.Euler(new Vector3(0, rotation, 0));
            GetComponent<Rigidbody>().MoveRotation(rot);
        }
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //Instantiate the bullet
            GameObject obj = Instantiate(bullet, aim.transform.position, Quaternion.identity) as GameObject;
            BulletScript b = obj.GetComponent<BulletScript>();
            Quaternion rot = Quaternion.Euler(new Vector3(0, rotation, 0));
            b.heading = rot;
        }
    }
}
