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

    public float XAccel = 30,
                 XDecel = 60,
                 XMaxVel = 60,
                 XVel = 0,
                 YAccel = -30,
                 YTermVel = -60,
                 YJump = 60,
                 YVel = 0;
    
//    public float Gravity = 9,
//                 JumpStrength = 30,
//                 MoveSpeed = 15;
//
//    public int JumpDuration = 10,
//               JumpFor = 0;
//
//    public bool CanJump = true;
//
    private CharacterController controller;
    CollisionFlags prevFlags;

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
			if (Jump.KeyDown)
			{
				YVel = YJump;
			}
			else
			{
				YVel = 0;
				if (MoveLeft.IsActive)
				{
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
		
		moveVec.x += XVel * Time.deltaTime;
		moveVec.y += YVel * Time.deltaTime;

        //if (MoveLeft.IsActive)
        //{
        //    moveVec.x -= MoveSpeed;
        //}

        //if (MoveRight.IsActive)
        //{
        //    moveVec.x += MoveSpeed;
        //}

        //if (prevFlags.Has(CollisionFlags.CollidedBelow))
        //{
        //    if (Jump.KeyDown)
        //    {
        //        JumpFor = JumpDuration;
        //    }
        //}
        //else
        //{
        //    moveVec.y -= Gravity;
        //}

        //if (JumpFor > 0)
        //{
        //    moveVec.y += JumpStrength;
        //    JumpFor -= 1; 
        //}

        prevFlags = controller.Move(moveVec * Time.deltaTime);
    }
}
