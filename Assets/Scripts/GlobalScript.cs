using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalScript : MonoBehaviour 
{
    public int score;
    public int life;
    public int numInvaders;
    public LevelData levelData;
    void Start()
    {
        score = levelData.score;
        life = 3;
        numInvaders = 30;
    }

    void Update()
    {
        if (numInvaders <= 0)
        {
            levelData.score += score;
            Time.timeScale = 1f;
            SceneManager.LoadScene(1);
        }
    }
}
