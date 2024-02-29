using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 
/// Ticking StackOverflowError time bomb will fix later
/// 
/// </summary>
public class GameEvents : MonoBehaviour
{
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
            WallrunEnter();
    }

    // Event is broadcasted whenever the player exits a wallrun
    public event Action OnWallrunExit;
    public void WallrunExit()
    {
        if (OnWallrunExit != null)
            WallrunExit();
    }

    // Event is broadcasted whenever the player begins to climb
    public event Action OnClimbEnter;
    public void ClimbEnter()
    {
        if (OnClimbEnter != null)
            ClimbEnter();
    }

    // Event is broadcasted whenever the player exits climb
    public event Action OnClimbExit;
    public void ClimbExit()
    {
        if (OnClimbExit != null)
            ClimbExit();
    }

    /*  * Game Over Events *   */

    // Event is broadcasted whenever the player wins
    public event Action OnLevelWon;
    public void LevelWon()
    {
        Debug.Log("You won!");
        if (OnLevelWon != null)
            LevelWon();
    }
}
