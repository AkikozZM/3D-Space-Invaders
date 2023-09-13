using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOSpawn : MonoBehaviour
{
    public GameObject spawn;
    public GameObject ufo;
    private float duration;
    void Start()
    {
        duration = 5;
    }

    void Update()
    {
        if (duration > 0)
        {
            duration -= Time.deltaTime;
        }
        
        if (duration <= 0)
        {
            duration = 10;
            Instantiate(ufo, spawn.transform.position, Quaternion.Euler(90, 0, 0));  
        }
    }
}
