using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateDetector : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Object_Picker picker;
    [SerializeField] Transform parentObj;
    private bool keyFragmentsFound = false;
    [SerializeField] float gate_descent_speed = 0.2f;
    public bool solvedCode = false;
    [SerializeField] float range = 2.5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!keyFragmentsFound && Vector3.Distance(transform.position, picker.transform.position) <= range)
        {
            if(picker.current_keys >= picker.MAX_KEYS)
            {
                
                keyFragmentsFound = true;
            }
        }

        if (keyFragmentsFound && solvedCode)
        {
            parentObj.position -= new Vector3(0, gate_descent_speed * Time.deltaTime, 0);
        }
    }

    public void OpenGate()
    {
        
    }
}
