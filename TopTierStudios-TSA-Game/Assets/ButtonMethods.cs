using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// 
/// This class contains the methods for each button.
/// 
/// </summary>
public class ButtonMethods : MonoBehaviour
{
    // Quits the game
    public void QuitApp()
    {
        Application.Quit();
    }

    // Loads the first level
    public void PlayGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    // Loads the exposition
    public void LoadExposition()
    {
        SceneManager.LoadScene("Exposition");
    }

    // Loads the how to play scene
    public void HowToPlay()
    {
        SceneManager.LoadScene("How 2 Play");
    }

    // Loads the main menu
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    // Loads Advanced Movement
    public void LoadAdvancedMovement()
    {
        SceneManager.LoadScene("Advanced Movement");
    }

    // Loads Settings menu
    public void LoadSettings()
    {
        SceneManager.LoadScene("Settings");
    }

    // Resume game
    public void Unpause()
    {
        GameEvents.current.PauseToggle();
    }

    // Toggle the music
    public void ToggleMusic()
    {
        GameEvents.current.MusicToggle();
    }
}
