using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    public TextMeshProUGUI currentPoints;
    public GlobalScript globalObj;

    void Update()
    {
        currentPoints.text = globalObj.score.ToString();
    }
}
