using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// This part of the PlayerMovement class captures player input.
/// 
/// </summary>
public partial class PlayerMovement : MonoBehaviour
{
    float horizontalInput;
    float verticalInput;
    
    private void GetPlayerInput()
    {
        // X and Z Movement
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // Y Movement
        if (Input.GetAxisRaw("Jump") != 0 && readyToJump && moveState != MovementState.airborne)
        {
            readyToJump = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }
}
