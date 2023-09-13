using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [Header("Attributes")]
    public float moveSpeed;
    public float cooldown;

    [Header("Reference")]
    public GameObject bullet;
    public GameObject aim;
    
    private bool canShoot;


    void Start()
    {
        canShoot = true;
    }
    private void FixedUpdate()
    {
        // Manipulate ship moves right or left
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            this.gameObject.transform.Translate(new Vector3(moveSpeed, 0, 0));
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            this.gameObject.transform.Translate(new Vector3(-moveSpeed, 0, 0));
        }
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && canShoot)
        {
            //Instantiate the bullet
            GameObject obj = Instantiate(bullet, aim.transform.position, Quaternion.identity) as GameObject;
            canShoot = false;
            StartCoroutine(fireCooldown());
        }
    }
    private IEnumerator fireCooldown()
    {
        yield return new WaitForSeconds(cooldown);
        canShoot = true;
    }
}
