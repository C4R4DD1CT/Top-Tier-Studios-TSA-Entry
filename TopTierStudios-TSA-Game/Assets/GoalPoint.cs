using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// 
/// This script allows the goal to load the next scene if the player wins.
/// 
/// </summary>
public class GoalPoint : MonoBehaviour
{
    public LayerMask playerMask;
    public float radius;

    private void FixedUpdate()
    {
        if (Physics.CheckSphere(transform.position, radius, playerMask))
        {
            GameEvents.current.LevelWon();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
