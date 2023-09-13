using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GroupAI : MonoBehaviour
{
    public bool isLock;
    public leftOrRight currentDirection;
    public GameObject missile;
    public float attkCycle;
    public GameObject invaderGreen;

    public enum leftOrRight
    {
        Left,
        Right
    }
    public float cooldown;
    public bool canMoveDown;
    private bool canMove;
    private bool canAttk;
    public int enemyNums;
    void Start()
    {
        StartCoroutine(Attk());
        canMove = true;
        cooldown = 1f;
        currentDirection = leftOrRight.Left;
        enemyNums = 30;
    }
    private void Update()
    {
        if (canMove)
        {
            AutoMovement();
        }
        if (canAttk)
        {
            AttackPlayer();
        }
    }

    private void AutoMovement()
    {
        canMove = false;
        if (currentDirection == leftOrRight.Left && !canMoveDown)
        {
            gameObject.transform.position -= new Vector3(1, 0, 0);
        }
        else if (currentDirection == leftOrRight.Right && !canMoveDown)
        {
            gameObject.transform.position += new Vector3(1, 0, 0);
        }
        else if ((currentDirection == leftOrRight.Left || 
            currentDirection == leftOrRight.Right) && 
            canMoveDown)
        {
            MoveDown();
        }
        StartCoroutine(CoolDown());
    }
    private IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(cooldown);
        canMove = true;
    }
    public void MoveDown()
    {
        GameObject.Find("invaders").gameObject.transform.position += new Vector3(0, 0, -1);
        canMoveDown = false;
    }
    private void AttackPlayer()
    {
        // Get player location
        GameObject ship = GameObject.Find("Ship").gameObject;
        Vector3 missilePosition = new Vector3(ship.transform.position.x,
                                              0, invaderGreen.transform.position.z);

        // Instantiate missile
        Instantiate(missile, missilePosition, Quaternion.Euler(90f, 0f, 0f));
        StartCoroutine(Attk());
    }

    private IEnumerator Attk()
    {
        canAttk = false;
        yield return new WaitForSeconds(attkCycle);
        canAttk = true;
    }
}
