using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.EventSystems.EventTrigger;

public class TitleScript : MonoBehaviour
{
    public void start()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
}
