using UnityEngine;
using System.Collections;
using System;

public static class Extensions
{
    public static bool Has<T>(this Enum type, T value)
    {
        try
        {
            return (((int)(object)type & (int)(object)value) == (int)(object)value);
        }
        catch
        {
            return false;
        }
    }
}

[RequireComponent(typeof(CharacterController))]
public class PlatformController : MyDerivedMono
{

    public Control MoveLeft,
                   MoveRight,
                   Jump;

    public float XAccel = 10,
                 XDecel = 20,
                 XMaxVel = 60,
                 XVel = 0,
                 YAccel = -10,
                 YTermVel = -60,
                 YJump = 10,
                 YVel = 0;
    
    private CharacterController controller;
    CollisionFlags prevFlags;
    public GameObject DrawObject;

	void Start () 
    {
        controller = GetComponent<CharacterController>();
        if (controller == null)
        {
            Debug.LogError("No character controller found on: " + name);
        }
	}
	
	void Update ()
    {
        Vector3 moveVec = Vector3.zero;

        if (prevFlags.Has(CollisionFlags.CollidedBelow))
        {
			if (Jump.IsActive)
			{
				YVel = YJump;
                audio.Play();
			}
			else
			{
				YVel = 0;
				if (MoveLeft.IsActive)
				{
                    DrawObject.transform.rotation = Quaternion.Euler(0, 180, 0);
					if (XVel > -1*XMaxVel)
					{
						if (XVel > 0)
						{
							XVel -= (XDecel * Time.deltaTime);
							if (XVel < 0)
							{
								XVel = 0;
							}
						}
						else
						{
							XVel -= (XAccel * Time.deltaTime);
							if (XVel<-1*XMaxVel)
							{
								XVel = -1*XMaxVel;
							}
						}
					}
				}
				else if (MoveRight.IsActive)
				{
                    DrawObject.transform.rotation = Quaternion.Euler(0, 0, 0);
					if (XVel < XMaxVel)
					{
						if (XVel < 0)
						{
							XVel += (XDecel * Time.deltaTime);
							if (XVel > 0)
							{
								XVel = 0;
							}
						}
						else
						{
							XVel += (XAccel * Time.deltaTime);
							if (XVel > XMaxVel)
							{
								XVel = XMaxVel;
							}
						}
					}
				}
				else
				{
					if (XVel < 0)
					{
						XVel += (XDecel * Time.deltaTime);
						if (XVel > 0)
						{
							XVel = 0;
						}
					}
					else if (XVel > 0)
					{
						XVel -= (XDecel * Time.deltaTime);
						if (XVel < 0)
						{
							XVel = 0;
						}
					}
				}
			}
        }
		else
		{
			YVel += (YAccel * Time.deltaTime);
			if (YVel < YTermVel)
			{
				YVel = YTermVel;
			}
		}
		
		if (prevFlags.Has(CollisionFlags.CollidedAbove))
		{
			if (YVel > 0)
			{
				YVel = 0;
			}
		}
		
		if (prevFlags.Has(CollisionFlags.CollidedSides))
		{
			XVel = 0;
		}
		
		moveVec.x += XVel;
		moveVec.y += YVel;

        prevFlags = controller.Move(moveVec * Time.deltaTime);
    }
}
