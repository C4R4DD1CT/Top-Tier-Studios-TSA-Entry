using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// This part of the PlayerMovement class controls the speed of the player.
/// It checks to see if the player wants to sprint, crouch, or walk.
/// This is stored in an enum holding the state of movement.
/// This script also limits the player's speed at any given moment.
/// It also conveniently performs the ground check as well.
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
        airborne
    }

    // Handle current state of player movement
    private void StateHandler()
    {
        if (GroundCheck())
        {
            // Crouch mode
            if (Input.GetAxisRaw("Crouch") != 0)
            {
                moveState = MovementState.crouching;
                moveSpeed = crouchSpeed;
                acceleration = crouchAccel;
            }

            // Sprint mode
            else if (Input.GetAxisRaw("Sprint") != 0)
            {
                moveState = MovementState.sprinting;
                moveSpeed = sprintSpeed;
                acceleration = sprintAccel;
            }

            // Walk mode
            else
            {
                moveState = MovementState.walking;
                moveSpeed = walkSpeed;
                acceleration = walkAccel;
            }
        }

        // Air mode
        else moveState = MovementState.airborne;
    }

    // Player can't break their speed limit
    private void SpeedControl()
    {
        // We don't need to work with the y-velocity here, jumps are jumps
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // Check to see if velocity needs limiting and limit if necessary
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }
}
