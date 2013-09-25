using UnityEngine;
using System.Collections;

public class CoinCounter : MonoBehaviour {
    public static int CoinCount = 0;

    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(0, 0, Screen.width * .25f, Screen.height * .1f));
        GUILayout.Label(CoinCount.ToString() + " COINS");
        GUILayout.EndArea();
    }
}
