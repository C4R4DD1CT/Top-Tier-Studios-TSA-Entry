using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// This script keeps the music off if the music was off.
/// 
/// </summary>
public class MediaPlayer2 : MonoBehaviour
{
    // Awake is called when the script instance is being loaded
    void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        //if (!GameEvents.musicToggleState) Destroy(transform.gameObject);
    }
}
