using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Object_Picker : MonoBehaviour
{
    // Start is called before the first frame update
    public int MAX_KEYS = 4;
    public int current_keys = 0;
    [SerializeField] bool checking_for_key_frags = false;
    [SerializeField] float object_pickup_distance = 7.0f;
    [SerializeField] Transform camera;
    [SerializeField] Text key_frag_text;
    [SerializeField] string objective = "Objective: Find all the keys, and enter the right passcode to open the gate.\n";
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit ray;
        if (Input.GetKeyDown(KeyCode.Mouse0) && Physics.Raycast(camera.transform.position, camera.forward, out ray, object_pickup_distance))
        {
           
            if(checking_for_key_frags)
            {
                if(ray.transform.tag == "key")
                {
                    current_keys += 1;
                    Destroy(ray.transform.gameObject);
                    if (current_keys < MAX_KEYS)
                    {
                        key_frag_text.text = objective + "\nkeys found: " + current_keys + " fragments";
                    }
                    else
                    {
                        key_frag_text.text = objective + "YOU FOUND ALL " + MAX_KEYS +" KEYS, GO TO THE GATE'S PADLOCK TO INSERT KEY!";
                    }
                }

                //Once all 4 keys are gained, put a message saying "Recieved 4 keys, Go to the gate"
            }
            
            if(ray.transform.tag == "code")
            {
                print("Clicked on a code block");
                ray.transform.GetComponent<CodeState>().OnCodeChange();
            }

            
        }
        
    }
}
