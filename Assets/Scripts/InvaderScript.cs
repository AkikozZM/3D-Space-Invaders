using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InvaderScript : MonoBehaviour
{
    public int reward;
    public GameObject parent;
    public GameObject explosion;
    public AudioClip deathKnell;
    public AudioSource bgm;

    private void Start()
    {
        bgm = GameObject.Find("bgm").gameObject.GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        // Being attked by player
        if (other.gameObject.CompareTag("Bullet"))
        {
            parent.GetComponent<GroupAI>().attkCycle -= 0.1f;
            parent.GetComponent<GroupAI>().cooldown -= 0.01f;
            bgm.pitch += 0.01f;
            GlobalScript gb = GameObject.Find("GlobalObj").GetComponent<GlobalScript>();
            // update current points
            gb.score += reward;
            // instantiate vfx and sfx
            Instantiate(explosion, gameObject.transform.position, Quaternion.AngleAxis(-90, Vector3.right));
            AudioSource.PlayClipAtPoint(deathKnell, gameObject.transform.position);
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Boundary"))
        {
            
            GroupAI gp = parent.gameObject.GetComponent<GroupAI>();
            if (gp.currentDirection == GroupAI.leftOrRight.Left && !gp.isLock)
            {
                gp.currentDirection = GroupAI.leftOrRight.Right;
                gp.canMoveDown = true;
                StartCoroutine(TempLock(gp));
            }
            else if (gp.currentDirection == GroupAI.leftOrRight.Right && !gp.isLock)
            {
                gp.currentDirection = GroupAI.leftOrRight.Left;
                gp.canMoveDown = true;
                StartCoroutine(TempLock(gp));
            }
        }
        if (other.gameObject.CompareTag("Obstacle"))
        {
            ObstacleScript obs = other.gameObject.GetComponent<ObstacleScript>();
            obs.Die();
        }
        if (other.gameObject.CompareTag("Ground"))
        {
            GameObject.Find("Ship").GetComponent<Ship>().GameOver();
        }
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Ship>().playerGetHurt();
        }
    }
    private IEnumerator TempLock(GroupAI gp)
    {
        gp.isLock = true;
        yield return new WaitForSeconds(1);
        gp.isLock = false;
    }

}
