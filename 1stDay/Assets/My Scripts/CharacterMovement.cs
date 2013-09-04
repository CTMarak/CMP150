using UnityEngine;
using System.Collections;
using System;
[Serializable]

public class CharacterControls
{
    public KeyCode MoveForward = KeyCode.W;
    public KeyCode MoveBack = KeyCode.S;
    public KeyCode MoveLeft = KeyCode.A;
    public KeyCode MoveRight = KeyCode.D;
    public KeyCode MoveUp = KeyCode.Space;
    public KeyCode MoveDown = KeyCode.LeftControl;
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
	    if(Input.GetKey(Controls.MoveForward))
		{
			transform.Translate(transform.forward*trueSpeed);
		}
        if (Input.GetKey(Controls.MoveBack))
        {
            transform.Translate(-1 * transform.forward * trueSpeed);
        }
        if (Input.GetKey(Controls.MoveLeft))
        {
            transform.Translate(-1 * transform.right * trueSpeed);
        }
        if (Input.GetKey(Controls.MoveRight))
        {
            transform.Translate(transform.right * trueSpeed);
        }
        if (Input.GetKey(Controls.MoveUp))
        {
            transform.Translate(transform.up * trueSpeed);
        }
        if (Input.GetKey(Controls.MoveDown))
        {
            transform.Translate(-1 * transform.up * trueSpeed);
        }
	}
}
