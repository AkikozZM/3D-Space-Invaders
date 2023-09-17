using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(selfDestroy());
    }
    private IEnumerator selfDestroy()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

}
