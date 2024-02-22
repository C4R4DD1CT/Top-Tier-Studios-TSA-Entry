using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform cameraPos;

    // Camera stays with player's cameraPosition object
    void Update()
    {
        transform.position = cameraPos.position;
    }
}
