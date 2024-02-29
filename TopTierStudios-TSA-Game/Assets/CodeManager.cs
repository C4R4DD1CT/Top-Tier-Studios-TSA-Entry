using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CodeManager : MonoBehaviour
{
    [SerializeField] CodeState.ColorState[] passcode = {CodeState.ColorState.Red, CodeState.ColorState.Yellow, CodeState.ColorState.Yellow, CodeState.ColorState.Blue};
    [SerializeField] CodeState[] codeStates;
    [SerializeField] GateDetector gateDetector;
    [SerializeField] TextMeshProUGUI text;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckValid()
    {
        
        for (int i = 0; i < codeStates.Length; i++)
        {
            if (codeStates[i].current != passcode[i])
            {
                text.text = "The color sequence is wrong! Try to find the correct combo!";
                text.color = Color.red;
                return;
            }
        }
        gateDetector.solvedCode = true;
        print("Correct Code, Open thy gate");
        text.text = "The color sequence is correct! The gate shall open once the requirements are met!";
        text.color = Color.green;
        
    }

}
