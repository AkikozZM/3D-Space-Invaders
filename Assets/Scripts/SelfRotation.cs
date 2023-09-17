using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfRotation : MonoBehaviour
{
    public AudioClip collect;
    void Update()
    {
        transform.Rotate(Vector3.forward * 240f * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Ship player = GameObject.Find("Ship").GetComponent<Ship>();
            player.doubleShoot = true;
            StartCoroutine(buffTime(player));
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            AudioSource.PlayClipAtPoint(collect, gameObject.transform.position);
        }
        if (other.gameObject.CompareTag("SelfDestroy"))
        {
            Destroy(this.gameObject);
        }
    }
    private IEnumerator buffTime(Ship player)
    {
        yield return new WaitForSeconds(3.5f);
        player.doubleShoot = false;
        Destroy(gameObject);
    }
}
