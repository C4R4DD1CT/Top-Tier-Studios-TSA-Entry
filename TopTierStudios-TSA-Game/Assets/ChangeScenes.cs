using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{

    bool invoked = false;

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Player") && !invoked)
        {
            invoked = true;
            Invoke("ChangeScene", 1.5f);
        }
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
