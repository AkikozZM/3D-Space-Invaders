using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOScript : MonoBehaviour
{
    public GlobalScript globalObj;
    private void Start()
    {
        globalObj = GameObject.Find("GlobalObj").gameObject.GetComponent<GlobalScript>();
    }
    private void FixedUpdate()
    {
        transform.Translate(Vector3.left * 8f * Time.deltaTime);
        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            int pts = Random.Range(50, 100);
            globalObj.score += pts;
            Destroy(gameObject);
        }
    }
}
