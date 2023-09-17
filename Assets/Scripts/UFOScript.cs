using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOScript : MonoBehaviour
{
    public GlobalScript globalObj;
    public AudioClip ufoSound;
    private void Start()
    {
        globalObj = GameObject.Find("GlobalObj").gameObject.GetComponent<GlobalScript>();
        AudioSource.PlayClipAtPoint(ufoSound, gameObject.transform.position);
    }
    private void FixedUpdate()
    {
        transform.Translate(Vector3.left * 7f * Time.deltaTime);
        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            int pts = Random.Range(50, 500);
            globalObj.score += pts;
            Destroy(gameObject);
        }
    }
}
