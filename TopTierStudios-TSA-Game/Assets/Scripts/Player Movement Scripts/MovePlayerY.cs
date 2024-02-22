using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 
/// This script is responsible for the y movement of the player (jumping).
/// It also performs the ground check.
/// 
/// </summary>
public partial class PlayerMovement : MonoBehaviour
{

    // Ground Check variables
    public float playerHeight;
    public LayerMask whatIsGround;

    // Jump variables
    public float jumpForce;
    public float jumpCooldown;
    bool readyToJump;
    

    // Ground Check
    private bool GroundCheck()
    {
        return Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f);
    }

    // Jump function
    private void Jump()
    {
        // Reset y-velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // Jump
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    // Reset jump
    private void ResetJump()
    {
        readyToJump = true;
    }
}
