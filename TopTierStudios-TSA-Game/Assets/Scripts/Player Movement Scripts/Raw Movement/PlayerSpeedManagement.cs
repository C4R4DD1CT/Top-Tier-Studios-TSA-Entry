using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// This part of the PlayerMovement class checks the movement state of the player.
/// Possible movement states include walking, sprinting, crouching, climbing, wallrunning, and airborne.
/// This is stored in an enum holding the state of movement, which can be accessed elsewhere in the class.
/// It also conveniently performs the ground check.
/// 
/// </summary>
public partial class PlayerMovement : MonoBehaviour
{
    [Header("Speed & Acceleration")]
    // Player speed variables
    public float walkSpeed;
    public float sprintSpeed;
    public float crouchSpeed;
    // Player acceleration variables
    public float crouchAccel;
    public float walkAccel;
    public float sprintAccel;

    // Stores state of player movement
    public MovementState moveState;
    public enum MovementState
    {
        walking,
        sprinting,
        crouching,
        climbing,
        wallrunning,
        airborne
    }

    // Handle current state of player movement
    private void StateHandler()
    {
        GroundCheck();
        if (grounded)
        {
            // Crouch mode
            if (Input.GetAxisRaw("Crouch") != 0)
            {
                if (moveState == MovementState.sprinting) GameEvents.current.SprintExit();
                moveState = MovementState.crouching;
                moveSpeed = crouchSpeed;
                acceleration = crouchAccel;
            }

            // Sprint mode
            else if (Input.GetAxisRaw("Sprint") != 0)
            {
                if (moveState != MovementState.sprinting) GameEvents.current.SprintEnter();
                moveState = MovementState.sprinting;
                moveSpeed = sprintSpeed;
                acceleration = sprintAccel;
            }

            // Walk mode
            else
            {
                if (moveState == MovementState.sprinting) GameEvents.current.SprintExit();
                moveState = MovementState.walking;
                moveSpeed = walkSpeed;
                acceleration = walkAccel;
            }
        }

        // Wallrun mode
        else if ((wallLeft || wallRight) && verticalInput > 0 && !exitingWall)
        {
            moveState = MovementState.wallrunning;
            moveSpeed = wallrunSpeed;
        }

        // Air mode
        else
        {
            //if (moveState == MovementState.sprinting) GameEvents.current.SprintExit();
            moveState = MovementState.airborne;
        }

        // Climb mode (needs to be checked regardless of state of ground check)
        if (wallFront && verticalInput > 0)
        {
            moveState = MovementState.climbing;
            moveSpeed = climbSpeed;
        }

        //Debug.Log(moveState);
    }
}
