using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 
/// Ticking StackOverflowError time bomb will fix later
/// I fixed it
/// 
/// </summary>
public class GameEvents : MonoBehaviour
{
    // Save music toggle state
    public static bool musicToggleState = true;

    // Creates a static Singleton that can be accessed wherever the GameEvents class is
    public static GameEvents current;

    private void Awake()
    {
        // Sets singleton reference to this script
        current = this;
    }

    /*  * Player State Change Events *  */

    // Event is broadcasted whenever the player enters a wallrun
    public event Action OnWallrunEnter;
    public void WallrunEnter()
    {
        if (OnWallrunEnter != null)
            OnWallrunEnter();
    }

    // Event is broadcasted whenever the player exits a wallrun
    public event Action OnWallrunExit;
    public void WallrunExit()
    {
        if (OnWallrunExit != null)
            OnWallrunExit();
    }

    // Event is broadcasted whenever the player begins to climb
    public event Action OnClimbEnter;
    public void ClimbEnter()
    {
        if (OnClimbEnter != null)
            OnClimbEnter();
    }

    // Event is broadcasted whenever the player exits climb
    public event Action OnClimbExit;
    public void ClimbExit()
    {
        if (OnClimbExit != null)
            OnClimbExit();
    }

    // Event is broadcasted whenever the player enters a sprint
    public event Action OnSprintEnter;
    public void SprintEnter()
    {
        if (OnSprintEnter != null)
            OnSprintEnter();
    }

    // Event is broadcasted whenever the player exits a sprint (without entering a climb or wallrun)
    public event Action OnSprintExit;
    public void SprintExit()
    {
        if (OnSprintExit != null)
            OnSprintExit();
    }

    // Event is broadcasted when pause is toggled
    public event Action OnPauseToggle;
    public void PauseToggle()
    {
        if (OnPauseToggle != null)
            OnPauseToggle();
    }

    // Event is broadcasted when music is toggled
    public event Action OnMusicToggle;
    public void MusicToggle()
    {
        if (OnMusicToggle != null)
            OnMusicToggle();
    }

    /*  * Game Over Events *   */

    // Event is broadcasted whenever the player wins
    public event Action OnLevelWon;
    public void LevelWon()
    {
        Debug.Log("You won!");
        if (OnLevelWon != null)
            OnLevelWon();
    }

    public event Action<bool> OnMusicToggleState;
    public void MusicToggleState(bool state)
    {
        musicToggleState = state;
    }
}
