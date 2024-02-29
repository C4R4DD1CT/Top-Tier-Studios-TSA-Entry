using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeState : MonoBehaviour
{
    public enum ColorState{
        Red,
        Blue,
        Yellow,
        Loading,
        Error,
        Default

        }
    public ColorState[] colorStates = { ColorState.Red, ColorState.Blue, ColorState.Yellow };
    private int colIndex = 0;
    public ColorState current = ColorState.Default;
    private Renderer renderer;
    [SerializeField] CodeManager manager;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        current = ColorState.Default;
        renderer.material.color = Color.gray;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCodeChange()
    {
        if (current != ColorState.Error)
        {
            colIndex = (colIndex + 1) % 3;
            print(colIndex);
            current = colorStates[colIndex];
            renderer.material.color = GetColor(current);
            manager.CheckValid();
        }

    }

    private Color GetColor(ColorState state)
    {
        if(state == ColorState.Red)
        {
            return Color.red;
        }else if(state == ColorState.Blue)
        {
            return Color.blue;
        }else if(state == ColorState.Yellow)
        {
            return Color.yellow;
        }else if(state == ColorState.Loading || state == ColorState.Default)
        {
            return Color.gray;
        }
        else
        {
            return Color.red;
        }
    }

   

    
}
