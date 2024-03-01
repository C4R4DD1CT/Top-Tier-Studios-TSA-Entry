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
    // Start is called before the first frame update
    void Awake()
    {
        if (!GameEvents.musicToggleState) Destroy(transform.gameObject);
    }
}
