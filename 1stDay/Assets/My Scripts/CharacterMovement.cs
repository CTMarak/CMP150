using UnityEngine;
using System.Collections;
using System;
[Serializable]

public class CharacterControls
{
    public Control MoveForward;
    public Control MoveBack;
    public Control MoveLeft;
    public Control MoveRight;
    public Control MoveUp;
    public Control MoveDown;
}

public class MyDerivedMono : MonoBehaviour
{
    public float XPos
    {
        get { return transform.position.x; }
        set
        {
            Vector3 myPos = transform.position;
            myPos.x = value;
            transform.position = myPos;
        }
    }
    public float YPos
    {
        get { return transform.position.y; }
        set
        {
            Vector3 myPos = transform.position;
            myPos.y = value;
            transform.position = myPos;
        }
    }
    public float ZPos
    {
        get { return transform.position.z; }
        set
        {
            Vector3 myPos = transform.position;
            myPos.z = value;
            transform.position = myPos;
        }
    }
}

public class CharacterMovement : MyDerivedMono {
	
	public float MoveSpeed = 5f;
    public CharacterControls Controls = new CharacterControls();

    private float trueSpeed
    {
        get { return MoveSpeed * Time.deltaTime; }
    }
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	    if(Controls.MoveForward.IsActive)
		{
			transform.Translate(transform.forward*trueSpeed);
		}
        if (Controls.MoveBack.IsActive)
        {
            transform.Translate(-1 * transform.forward * trueSpeed);
        }
        if (Controls.MoveLeft.IsActive)
        {
            transform.Translate(-1 * transform.right * trueSpeed);
        }
        if (Controls.MoveRight.IsActive)
        {
            transform.Translate(transform.right * trueSpeed);
        }
        if (Controls.MoveUp.IsActive)
        {
            transform.Translate(transform.up * trueSpeed);
        }
        if (Controls.MoveDown.IsActive)
        {
            transform.Translate(-1 * transform.up * trueSpeed);
        }
	}
}
