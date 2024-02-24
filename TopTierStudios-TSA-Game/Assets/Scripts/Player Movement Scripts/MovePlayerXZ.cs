using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// This part of the PlayerMovement class is in charge of x and z movement.
/// A separate script is designed to handle ground checks and jumps.
/// Within this script will also exist variables meant for movement.
/// One purpose of splitting the file up into several parts is to allow for one of said parts to be disabled at any given time.
/// 
/// </summary>
public partial class PlayerMovement : MonoBehaviour
{
    // Player speed variables
    private float moveSpeed;
    private float acceleration;
    public float airMultiplier;
    public float groundDrag;

    Vector3 moveDirection;

    // Move the player
    private void MovePlayer()
    {
        // Calculate movement direction
        moveDirection = (orientation.forward * verticalInput) + (orientation.right * horizontalInput);

        // Slope behavior
        if (OnSlope())
        {
            rb.AddForce(GetSlopeMoveDirection() * moveSpeed);
            if (rb.velocity.y > 0)
                rb.AddForce(Vector3.down * 10f, ForceMode.Force);
        }

        // Disable gravity while on a slope (If you're in the air you're not on a slope)
        rb.useGravity = !OnSlope();

        // Do ground check and set drag as needed before adding force in movement direction
        if (moveState != MovementState.airborne)
        {
            rb.drag = groundDrag;
            rb.AddForce(moveDirection.normalized * acceleration, ForceMode.Force);
        }
        else
        {
            rb.drag = 0;
            rb.AddForce(moveDirection.normalized * acceleration * airMultiplier, ForceMode.Force);
        }

        
        // Keep velocity within intended limit
        SpeedControl();
        Debug.Log(rb.velocity.magnitude);
    }
}
