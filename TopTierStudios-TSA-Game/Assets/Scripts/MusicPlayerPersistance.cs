using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 
/// This script plays the music for the game.
/// 
/// </summary>
public class MusicPlayerPersistance : MonoBehaviour
{
    public AudioSource music;

    // Don't destroy the object on new load and subscribe to game events
    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);

        GameEvents.current.OnMusicToggle += ToggleMusic;

        // Prevent duplicate objects
        if (GameObject.FindGameObjectsWithTag("Music Player").Length > 1)
            Destroy(transform.gameObject);
    }

    private void ToggleMusic()
    {
        music.enabled = !music.enabled;
    }
}
