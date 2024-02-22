using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// This part of the PlayerMovement script handles more intricate parts of crouching.
/// In essence, it scales the player's height and changes the playerHeight in ground check to compensate.
/// 
/// </summary>
public partial class PlayerMovement : MonoBehaviour
{
    // Crouch variables
    public float crouchYScale;
    public float startYScale;

    // Handle scale of player when crouched and uncrouched
    public void CrouchHandler()
    {
        if (moveState == MovementState.crouching)
        {
            transform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z);
        }
        else
            transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z);
    }
}
