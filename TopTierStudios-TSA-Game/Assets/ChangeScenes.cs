using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameEvents.current.LevelWon();
            Invoke(nameof(ChangeScene), 1.5f);
        }
    }

    private void ChangeScene()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex + 1));
    }
}
