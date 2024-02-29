using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    // Connect to current orientation, rigidbody, and camera
    [Header("Object References")]
    public Transform orientation;
    public Rigidbody rb;
    public int deathDist;
    //public Transform playerKaCamera;

    // Start is called before the first frame update
    private void Start()
    {
        ResetJump();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        startYScale = transform.localScale.y;

        // Subscribe to goal event
        GameEvents.current.OnLevelWon += LevelWonCommands;
    }

    // Update is called once per frame
    private void Update()
    {
        // Check to see if player has fallen out of scene and reset scene if so
        if (transform.position.y < deathDist)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        // Get the player input
        GetPlayerInput();

        // Check player state
        StateHandler();

        // Additional state intricacies
        CrouchHandler();
        CheckForClimb();
        WallrunState();
    }

    // FixedUpdate is called on set intervals
    private void FixedUpdate()
    {
        // Move the player
        MovePlayer();
    }

    // Happens on Level Won
    private void LevelWonCommands()
    {
        // Shoot player into sky after Level 2 finishes
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level 2"))
            rb.AddForce(new Vector3(0f, 80f, 0f), ForceMode.Impulse);
    }
}
