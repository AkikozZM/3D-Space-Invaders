using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvaderScript : MonoBehaviour
{
    public int reward;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            GlobalScript gb = GameObject.Find("GlobalObj").GetComponent<GlobalScript>();
            gb.score += reward;
            Destroy(gameObject);
        }
    }
}
