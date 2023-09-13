using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    public TextMeshProUGUI currentPoints;
    public TextMeshProUGUI finalPoints;
    public TextMeshProUGUI currentHP;
    public GlobalScript globalObj;

    void Update()
    {
        currentPoints.text = globalObj.score.ToString();
        currentHP.text = globalObj.life.ToString();
        finalPoints.text = currentPoints.text;
    }
    public void restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
}
