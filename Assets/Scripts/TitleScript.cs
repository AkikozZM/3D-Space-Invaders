using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class TitleScript : MonoBehaviour
{
    private GUIStyle buttonStyle;
    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(10, Screen.height / 2 + 100, Screen.width - 10, 200));
        if (GUILayout.Button("New Game"))
        {
            Application.LoadLevel("BasicSpaceInvader");
        }
        if (GUILayout.Button("High score"))
        {
            Debug.Log("You should implement a high score screen.");
        }
        if (GUILayout.Button("Exit"))
        {
            Application.Quit();
            Debug.Log("Application.Quit() only works in build,not in editor");
        }
        GUILayout.EndArea();
    }
}
