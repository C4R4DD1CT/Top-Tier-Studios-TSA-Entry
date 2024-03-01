using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 
/// Controls the player's camera movement (allows them to look up and down and right and left with the mouse).
/// 
/// </summary>
public class PlayerCam : MonoBehaviour
{
    // Camera control variables
    [Header("Camera Controls")]
    public float sensX;
    public float sensY;
    public float zoomTime;
    public float specialFOV;
    private float standardFOV;
    public Transform orientation;
    public Camera playerKaCamera;
    float xRotation;
    float yRotation;

    // Start is called before the first frame update
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        standardFOV = playerKaCamera.fieldOfView;

        // Subscribe to game events
        GameEvents.current.OnWallrunEnter += specialFOVSwitch;
        GameEvents.current.OnClimbEnter += specialFOVSwitch;
        GameEvents.current.OnSprintEnter += specialFOVSwitch;
        GameEvents.current.OnClimbExit += standardFOVSwitch;
        GameEvents.current.OnWallrunExit += standardFOVSwitch;
        GameEvents.current.OnSprintExit += standardFOVSwitch;
    }

    // Unsubscribe from game events if disabled
    private void OnDisable()
    {
        GameEvents.current.OnWallrunEnter -= specialFOVSwitch;
        GameEvents.current.OnClimbEnter -= specialFOVSwitch;
        GameEvents.current.OnSprintEnter -= specialFOVSwitch;
        GameEvents.current.OnClimbExit -= standardFOVSwitch;
        GameEvents.current.OnWallrunExit -= standardFOVSwitch;
        GameEvents.current.OnSprintExit += standardFOVSwitch;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCamera();
    }

    // Gets input to change camera
    private void UpdateCamera()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * sensY;

        // Apply mouse input
        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Rotate camera and player orientation
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    // Switches to special FOV
    private void specialFOVSwitch()
    {
        playerKaCamera.fieldOfView = Mathf.Lerp(playerKaCamera.fieldOfView, specialFOV, zoomTime);
    }

    // Switches to regular FOV
    private void standardFOVSwitch()
    {
        playerKaCamera.fieldOfView = Mathf.Lerp(playerKaCamera.fieldOfView, standardFOV, zoomTime);
    }
}
