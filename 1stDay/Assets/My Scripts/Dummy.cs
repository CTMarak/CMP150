using UnityEngine;
using System.Collections;
using System;
[Serializable]

public class DummyControls
{
    public Control Tester;
}

public class Dummy : MonoBehaviour
{

    public DummyControls Controls = new DummyControls();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Controls.Tester.KeyDown)
        {
            Debug.Log("Dummy is Down!");
        }
        if (Controls.Tester.KeyUp)
        {
            Debug.Log("Dummy is Up!");
        }
        if (Controls.Tester.IsActive)
        {
            Debug.Log("Dummy is Active!");
        }
	}
}
