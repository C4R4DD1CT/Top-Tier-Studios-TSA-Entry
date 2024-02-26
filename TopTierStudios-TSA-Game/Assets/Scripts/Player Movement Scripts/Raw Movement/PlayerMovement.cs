using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// This is the master part of the player movement class.
/// For ease of management, the class for player movement has been split into several partial classes.
/// This class contains the Start and Update functions.
/// Check the Player Movement folder to see all aspects of player movement.
/// 
/// </summary>
public partial class PlayerMovement : MonoBehaviour
{
    // Connect to current orientation and rigidbody
    [Header("Object References")]
    public Transform orientation;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        ResetJump();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        startYScale = transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        // Get the player input
        GetPlayerInput();

        // Check player state
        StateHandler();

        // Additional state intricacies
        CrouchHandler();
        CheckForClimb();
    }

    // FixedUpdate is called on set intervals
    private void FixedUpdate()
    {
        // Move the player
        MovePlayer();
    }
}
