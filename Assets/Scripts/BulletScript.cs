using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float attkSpeed;
    public AudioClip fireSound;

    void Start()
    {
        GetComponent<Rigidbody>().drag = 0;
        GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, attkSpeed * 50f, 0));
        AudioSource.PlayClipAtPoint(fireSound, gameObject.transform.position);
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
        if (collider.CompareTag("Missile"))
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
        if (other.CompareTag("Invader"))
        {
            Destroy(gameObject);
        }
    }
}
