using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 
/// This part of the PlayerMovement class controls the player's ability to wallrun.
/// Some walls are wallrunnable. Scalable walls are also wallrunnable.
/// 
/// </summary>
public partial class PlayerMovement : MonoBehaviour
{
    [Header("Wallrunning")]
    public LayerMask wallrunnable;
    public float wallrunSpeed;
    public float wallrunAccel;
    public float wallJumpUpForce;
    public float wallJumpOutForce;
    public float maxWallrunTime;
    private float wallrunTimer;
    private bool wallrunning;

    [Header("Detection")]
    public float minJumpHeight;
    public float exitingWallTime;
    private float exitingWallTimer;
    private bool exitingWall;

    private RaycastHit hitLeft;
    private RaycastHit hitRight;
    private bool wallLeft;
    private bool wallRight;

    // Check for walls on the left and right of the player
    private void RightLeftWallCheck()
    {
        wallRight = Physics.Raycast(transform.position, orientation.right, out hitRight, detectionLength, wallrunnable);
        wallLeft = Physics.Raycast(transform.position, -orientation.right, out hitLeft, detectionLength, wallrunnable);
    }

    // Player wallrunning
    private void WallrunState()
    {
        RightLeftWallCheck();

        // Determine whether the player can and wants to wallrun
        if (moveState == MovementState.wallrunning)
        {
            if (!wallrunning)
                StartWallrun();
        }

        // Stop wallrunning if the player doesn't want to wallrun
        else if (wallrunning) StopWallrun();

        // If the player can and wants to wallrun let them wallrun
        if (wallrunning) WallrunMovement();
    }

    // Wallrun movement
    private void WallrunMovement()
    {
        rb.useGravity = false;
        rb.velocity = (rb.velocity.y < 0) ? new Vector3(rb.velocity.x, 0f, rb.velocity.z) : rb.velocity;

        // Find forward direction relative to wall
        Vector3 wallNormal = wallRight ? hitRight.normal : hitLeft.normal;
        Vector3 wallForward = Vector3.Cross(wallNormal, transform.up).normalized;

        // Check to make sure it isn't backwards
        if ((orientation.forward - wallForward).magnitude > (orientation.forward - -wallForward).magnitude)
            wallForward = -wallForward;

        // Add force for wallrunning
        rb.AddForce(wallForward * wallrunAccel, ForceMode.Force);

        // Stick player to wall
        if (!(wallLeft && horizontalInput > 0) && !(wallRight && horizontalInput < 0))
            rb.AddForce(-wallNormal * 100f, ForceMode.Force);
    }

    // Wallrun jump
    private void WallJump()
    {
        // Find outward direction relative to wall
        Vector3 wallNormal = wallRight ? hitRight.normal : hitLeft.normal;

        // Determine force to use
        Vector3 forceToApply = transform.up * wallJumpUpForce + wallNormal * wallJumpOutForce;

        // Apply force
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(forceToApply, ForceMode.Force);
    }

    // Start and stop wallruns
    private void StartWallrun()
    {
        wallrunning = true;
        GameEvents.current.WallrunEnter();
    }
    private void StopWallrun()
    {
        wallrunning = false;
        //rb.AddForce(-rb.velocity / 2, ForceMode.Impulse);
        GameEvents.current.WallrunExit();
    }
}
