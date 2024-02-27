using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateDetector : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Object_Picker picker;
    [SerializeField] Transform parentObj;
    private bool unlocked = false;
    [SerializeField] float gate_descent_speed = 0.2f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, picker.transform.position) < 1.5f || unlocked)
        {
            if(picker.current_keys >= picker.MAX_KEYS)
            {
                parentObj.position -= new Vector3(0, gate_descent_speed * Time.deltaTime, 0);
                unlocked = true;
            }
        }
    }
}
