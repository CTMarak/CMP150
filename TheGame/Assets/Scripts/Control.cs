using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Control : MonoBehaviour {

    public string Name = "Control";
    private List<ControllerInput> inputs = new List<ControllerInput>();
    public bool IsActive
    {
        get { return isActive; }
    }
    public bool KeyDown
    {
        get { return keyDown; }
    }
    public bool KeyUp
    {
        get { return keyUp; }
    }
    private bool isActive = false;
    private bool keyDown = false;
    private bool keyUp = false;

	// Use this for initialization
	void Start () {
        foreach (var input in gameObject.GetComponents<ControllerInput>())
        {
            if (inputs.Contains(input)) continue;
            inputs.Add(input);
        }
	}
	
	// Update is called once per frame
	void Update () {
        isActive = false;
        keyDown = false;
        keyUp = false;
        foreach (var input in inputs)
        {
            if (input.IsActive)
            {
                isActive = true;
            }
            if (input.KeyDown)
            {
                keyDown = true;
            }
            if (input.KeyUp)
            {
                keyUp = true;
            }
        }
	}
}
