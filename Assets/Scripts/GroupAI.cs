using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GroupAI : MonoBehaviour
{
    public bool isLock;
    public leftOrRight currentDirection;
    public enum leftOrRight
    {
        Left,
        Right
    }
    public float cooldown;
    private bool canMove;
    void Start()
    {
        canMove = true;
        cooldown = 1f;
        currentDirection = leftOrRight.Left;
    }
    private void Update()
    {
        if (canMove)
        {
            AutoMovement();
        }
    }

    private void AutoMovement()
    {
        canMove = false;
        if (currentDirection == leftOrRight.Left)
        {
            gameObject.transform.position -= new Vector3(1, 0, 0);
        }
        else if (currentDirection == leftOrRight.Right)
        {
            gameObject.transform.position += new Vector3(1, 0, 0);
        }
        StartCoroutine(CoolDown());
    }
    private IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(cooldown);
        canMove = true;
    }
}
