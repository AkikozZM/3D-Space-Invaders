using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public GameObject explosion;
    public int pointValue;
    public AudioClip deathKnell;
    public void Die()
    {
        InstantiateExplosion();
        PlayDeathAudio();
        AddScore();
        Destroy(gameObject);
    }
    private void InstantiateExplosion()
    {
        Instantiate(explosion, gameObject.transform.position, Quaternion.AngleAxis(-90, Vector3.right));
    }
    private void AddScore()
    {
        GameObject obj = GameObject.Find("GlobalObj");
        GlobalScript g = obj.GetComponent<GlobalScript>();
        g.score += pointValue;
    }
    private void PlayDeathAudio()
    {
        AudioSource.PlayClipAtPoint(deathKnell, gameObject.transform.position);
    }
}
