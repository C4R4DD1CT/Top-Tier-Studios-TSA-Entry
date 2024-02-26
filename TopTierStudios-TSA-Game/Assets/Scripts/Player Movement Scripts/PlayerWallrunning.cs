using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 
/// This part of the PlayerMovement class controls the player's ability to wallrun.
/// _ walls are wallrunnable. Scalable walls are also wallrunnable.
/// 
/// </summary>
public partial class PlayerMovement : MonoBehaviour
{
    [Header("Wallrunning")]
    public LayerMask wallrunnable;
    public float wallrunSpeed;
    public float wallrunAccel;
    public float maxWallrunTime;
    private float wallrunTimer;
    private bool wallrunning;

    [Header("Detection")]
    public float minJumpHeight;

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
        else if (wallrunning) StopWallrun();

        // If the player can and wants to wallrun let them wallrun
        if (wallrunning) WallrunMovement();
    }

    // Wallrun movement
    private void WallrunMovement()
    {
        rb.useGravity = false;
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

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

    // Start and stop wallruns
    private void StartWallrun()
    {
        wallrunning = true;
    }
    private void StopWallrun()
    {
        wallrunning = false;
    }
}
