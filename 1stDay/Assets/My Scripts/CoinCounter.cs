using UnityEngine;
using System.Collections;

public class CoinCounter : MonoBehaviour {
    public static int CoinCount = 0;
    public static bool Win = false;

    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(0, 0, Screen.width * .25f, Screen.height * .1f));
        GUILayout.Label("SCORE: " + CoinCount.ToString());
        GUILayout.EndArea();
        if (Win)
        {
            GUILayout.BeginArea(new Rect(Screen.width * .3f, Screen.height * .3f, Screen.width * .4f, Screen.height * .4f));
            GUILayout.Label("Y O U   W I N ! ! !");
            GUILayout.EndArea();
        }
        GUILayout.BeginArea(new Rect(0, Screen.height * .9f, Screen.width, Screen.height * .1f));
        GUILayout.Label("Audio: EP+ by Tom Woxom");
        GUILayout.EndArea();
    }
}
