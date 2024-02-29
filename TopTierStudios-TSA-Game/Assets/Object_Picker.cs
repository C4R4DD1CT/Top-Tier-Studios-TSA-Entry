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
                        key_frag_text.text = "key frags: " + current_keys + " fragments";
                    }
                    else
                    {
                        key_frag_text.text = "YOU FOUND THE KEY FRAGMENTS, GO TO THE GATE!";
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
