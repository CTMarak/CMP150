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
    
    public float Gravity = 9,
                 JumpStrength = 30,
                 MoveSpeed = 15;

    public int JumpDuration = 10,
               JumpFor = 0;

    public bool CanJump = true;

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

        if (MoveLeft.IsActive)
        {
            moveVec.x -= MoveSpeed;
        }

        if (MoveRight.IsActive)
        {
            moveVec.x += MoveSpeed;
        }

        if (prevFlags.Has(CollisionFlags.CollidedBelow))
        {
            if (Jump.KeyDown)
            {
                JumpFor = JumpDuration;
            }
        }
        else
        {
            moveVec.y -= Gravity;
        }

        if (JumpFor > 0)
        {
            moveVec.y += JumpStrength;
            JumpFor -= 1; 
        }

        prevFlags = controller.Move(moveVec * Time.deltaTime);
    }
}
