using UnityEngine;
using System.Collections;

public abstract class ControllerInput : MonoBehaviour {
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

    protected bool isActive = false;
    protected bool keyDown = false;
    protected bool keyUp = false;
}
