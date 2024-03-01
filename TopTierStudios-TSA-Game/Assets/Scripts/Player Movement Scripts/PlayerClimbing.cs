using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 
/// This part of the PlayerMovement class allows for certain walls to be scalable.
/// It works by defining a specific layer for climbable walls and checking to see if the player is looking at and touching one.
/// Walking into a scalable wall will cause the player to climb.
/// 
/// </summary>
public partial class PlayerMovement : MonoBehaviour
{
    [Header("Climbing")]
    public float climbSpeed;
    public LayerMask climbable;
    private bool climbing;

    [Header("Wall Detection")]
    public float detectionLength;
    public float sphereCastRadius;
    public float maxWallLookAngle;
    public float curvedWallLookAngle;
    private float wallLookAngle;

    private RaycastHit wallHit;
    private bool wallFront;

    // Player climbing
    private void CheckForClimb()
    {
        FrontWallCheck();

        // Check to see if the player can and wants to climb
        if (moveState == MovementState.climbing)
        {
            if (!climbing) StartClimbing();
        }
        else if (climbing) StopClimbing();

        // If the player wants to climb let them climb
        if (climbing) ClimbingMovement();
    }

    // Check for walls
    private void FrontWallCheck()
    {
        wallFront = Physics.SphereCast(transform.position, sphereCastRadius, orientation.forward, out wallHit, detectionLength, climbable);
        wallLookAngle = Vector3.Angle(orientation.forward, -wallHit.normal);
    }

    // Set velocity for climbing
    private void ClimbingMovement()
    {
        rb.velocity = new Vector3(rb.velocity.x, climbSpeed, rb.velocity.z);
    }

    // Functions to start and stop climbing
    private void StartClimbing()
    {
        climbing = true;
        GameEvents.current.ClimbEnter();
    }
    private void StopClimbing()
    {
        climbing = false;
        GameEvents.current.ClimbExit();
    }
}
