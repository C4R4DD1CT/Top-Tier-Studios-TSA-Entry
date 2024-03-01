using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// 
/// This script plays the music for the game.
/// 
/// </summary>
public class MusicPlayerPersistance : MonoBehaviour
{
    public AudioSource music;

    private void OnLevelWasLoaded(int level)
    {
        // Subscribe to the new GameEvents thing
        GameEvents.current.OnMusicToggle += ToggleMusic;

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Dragon Scene"))
        {
            Destroy(transform.gameObject);
        }
    }

    // Don't destroy the object on new load and subscribe to game events
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);

        GameEvents.current.OnMusicToggle += ToggleMusic;

        // Prevent duplicate objects
        if (GameObject.FindGameObjectsWithTag("Music Player").Length > 1)
            Destroy(transform.gameObject);
    }

    public void ToggleMusic()
    {
        music.enabled = !music.enabled;
    }

    private void OnDestroy()
    {
        GameEvents.current.OnMusicToggle -= ToggleMusic;
        GameEvents.current.MusicToggleState(music.enabled);
    }
}
