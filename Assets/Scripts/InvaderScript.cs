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
    public GlobalScript global;
    private bool isDied;

    private void Start()
    {
        isDied = false;
        bgm = GameObject.Find("bgm").gameObject.GetComponent<AudioSource>();
        global = GameObject.Find("GlobalObj").gameObject.GetComponent<GlobalScript>();
    }
    private void OnTriggerEnter(Collider other)
    {
        // Being attked by player
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            parent.GetComponent<GroupAI>().attkCycle -= 0.02f;
            parent.GetComponent<GroupAI>().cooldown -= 0.01f;
            bgm.pitch += 0.01f;
            GlobalScript gb = GameObject.Find("GlobalObj").GetComponent<GlobalScript>();
            // update current points
            gb.score += reward;
            // instantiate vfx and sfx
            BeAttked();
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
        if (other.gameObject.CompareTag("Obstacle") && !isDied)
        {
            ObstacleScript obs = other.gameObject.GetComponent<ObstacleScript>();
            obs.Die();
        }
        if (other.gameObject.CompareTag("Ground") && !isDied)
        {
            GameObject.Find("Ship").GetComponent<Ship>().GameOver();
        }
        if (other.gameObject.CompareTag("Player") && !isDied)
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
    private void BeAttked()
    {
        Instantiate(explosion, gameObject.transform.position, Quaternion.AngleAxis(-90, Vector3.right));
        AudioSource.PlayClipAtPoint(deathKnell, gameObject.transform.position);
        this.gameObject.GetComponent<Rigidbody>().useGravity = true;
        this.gameObject.GetComponent<BoxCollider>().isTrigger = false;
        this.gameObject.transform.SetParent(null);
        this.gameObject.layer = 6;
        isDied = true;
        global.numInvaders -= 1;
        //Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("SelfDestroy"))
        {
            Destroy(gameObject);
        }
    }

}
