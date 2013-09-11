using UnityEngine;
using System.Collections;

public class KeyboardInput : ControllerInput
{
    public KeyCode activationKey = KeyCode.Space;

    void Update()
    {
        isActive = Input.GetKey(activationKey);
        keyDown = Input.GetKeyDown(activationKey);
        keyUp = Input.GetKeyUp(activationKey);
    }
}