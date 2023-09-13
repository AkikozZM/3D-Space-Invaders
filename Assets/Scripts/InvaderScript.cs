using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InvaderScript : MonoBehaviour
{
    public int reward;
    public GameObject parent;

    private void OnCollisionEnter(Collision collision)
    {


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            GlobalScript gb = GameObject.Find("GlobalObj").GetComponent<GlobalScript>();
            gb.score += reward;
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Boundary"))
        {
            
            GroupAI gp = parent.gameObject.GetComponent<GroupAI>();
            Debug.Log(gp.currentDirection);
            if (gp.currentDirection == GroupAI.leftOrRight.Left && !gp.isLock)
            {
                gp.currentDirection = GroupAI.leftOrRight.Right;
                StartCoroutine(TempLock(gp));
            }
            else if (gp.currentDirection == GroupAI.leftOrRight.Right && !gp.isLock)
            {
                gp.currentDirection = GroupAI.leftOrRight.Left;
                StartCoroutine(TempLock(gp));
            }
        }
    }
    private IEnumerator TempLock(GroupAI gp)
    {
        gp.isLock = true;
        yield return new WaitForSeconds(1);
        gp.isLock = false;
    }

}
