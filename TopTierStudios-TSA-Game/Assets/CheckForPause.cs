using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckForPause : MonoBehaviour
{
    public Canvas canvas;
    private bool paused;

    // Disable the pause screen and subscribe to game events
    void Start()
    {
        canvas.enabled = false;
        Time.timeScale = 1f;
        GameEvents.current.OnPauseToggle += TogglePause;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameEvents.current.PauseToggle();
        }
    }

    // Toggle pause
    private void TogglePause()
    {
        paused = !paused;
        if (paused)
        {
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            canvas.enabled = true;
        }
        else
        {
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            canvas.enabled = false;
        }
    }
}
