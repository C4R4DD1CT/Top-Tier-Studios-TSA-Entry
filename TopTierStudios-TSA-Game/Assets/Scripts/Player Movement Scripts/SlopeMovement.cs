using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 
/// This part of the PlayerMovement class controls the slope movement of the player.
/// 
/// </summary>
public partial class PlayerMovement : MonoBehaviour
{
    [Header("Slope Movement")]
    public RaycastHit slopeHit;
    public float maxSlopeAngle;

    // Checks to see if the player is on a slope
    private bool OnSlope()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight * 0.5f + 0.2f))
        {
            // There is a surface underneath the player
            float slopeAngle = Vector3.Angle(Vector3.up, slopeHit.normal);
            return slopeAngle < maxSlopeAngle && slopeAngle != 0;
        }
        // Player is in the air
        return false;
    }

    // Find the forward direction relative to slope
    private Vector3 GetSlopeMoveDirection()
    {
        return Vector3.ProjectOnPlane(moveDirection, slopeHit.normal).normalized;
    }
}
