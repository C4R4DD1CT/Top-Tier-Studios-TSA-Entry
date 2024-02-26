using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 
/// This is the script that allows certain walls to be scalable.
/// It works by defining a specific layer for climbable walls and checking to see if the player is looking at them.
/// If the player wishes to walk into a scalable wall, they will climb it instead.
/// 
/// </summary>
public class PlayerClimbing : MonoBehaviour
{
    [Header("Climbing Scripts")]
    [Header("Object References")]
    public Transform orientation;
    public Rigidbody rb;
    public LayerMask climbable;

    [Header("Climbing")]
    public float climbSpeed;
    private bool climbing;

    [Header("Wall Detection")]
    public float detectionLength;
    public float sphereCastRadius;
    public float maxWallLookAngle;
    public float curvedWallLookAngle;
    private float wallLookAngle;

    private RaycastHit wallHit;

    // Get the rigidbody
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update runs once per frame
    private void Update()
    {
        ToClimbOrNotToClimb();
        if (climbing) ClimbingMovement();
    }

    // Change climbing state
    private void ToClimbOrNotToClimb()
    {
        if (WallCheck() && Input.GetAxisRaw("Vertical") > 0)
        {
            if (!climbing) StartClimbing();
        }
        else if (climbing) StopClimbing();
    }

    // Check for walls
    private bool WallCheck()
    {
        bool wallFront = Physics.SphereCast(transform.position, sphereCastRadius, orientation.forward, out wallHit, detectionLength, climbable);
        wallLookAngle = Vector3.Angle(orientation.forward, -wallHit.normal);
        return wallFront;
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
    }
    private void StopClimbing()
    {
        climbing = false;
    }
}
