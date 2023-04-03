using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Functions : MonoBehaviour
{
    string currentColor = "Red";
    string oldColor = "";

    public GameObject Red;
    public GameObject Yellow;
    public GameObject Green;
    Renderer redRenderer;
    Renderer yellowRenderer;
    Renderer greenRenderer;

    
    // Start is called before the first frame update
    void Start()
    {
        redRenderer = Red.GetComponent<Renderer>();
        yellowRenderer = Yellow.GetComponent<Renderer>();
        greenRenderer = Green.GetComponent<Renderer>();
    }

    void SetColor(string color, int pos = 0)
    {
        switch(pos)
        {
            case 0:
                switch(color)
                {
                    case "Red":
                        redRenderer.material.color = Color.red;
                        break;
                    case "Yellow":
                        redRenderer.material.color = Color.yellow;
                        break;
                    case "Green":
                        redRenderer.material.color = Color.green;
                        break;
                    default:
                        break;
                }
                yellowRenderer.material.color = Color.black;
                greenRenderer.material.color = Color.black;
                break;
            case 1:
                switch(color)
                {
                    case "Red":
                        yellowRenderer.material.color = Color.red;
                        redRenderer.material.color = Color.red;
                        break;
                    case "Yellow":
                        yellowRenderer.material.color = Color.yellow;
                        redRenderer.material.color = Color.yellow;
                        break;
                    case "Green":
                        yellowRenderer.material.color = Color.green;
                        redRenderer.material.color = Color.green;
                        break;
                    default:
                        break;
                }
                greenRenderer.material.color = Color.black;
                break;
            case 2:
                switch(color)
                {
                    case "Red":
                        greenRenderer.material.color = Color.red;
                        break;
                    case "Yellow":
                        greenRenderer.material.color = Color.yellow;
                        break;
                    case "Green":
                        greenRenderer.material.color = Color.green;
                        break;
                    default:
                        break;
                }
                yellowRenderer.material.color = Color.black;
                redRenderer.material.color = Color.black;
                break;
            default:
                redRenderer.material.color = Color.black;
                yellowRenderer.material.color = Color.black;
                greenRenderer.material.color = Color.black;
                break;
        }
        
        currentColor = color;
    }

    public float looper;
    int posi = 0;
    // Update is called once per frame
    void Update()
    {
        looper = Time.time % 10;

        if(looper>5)
        {
            posi = 2;
            currentColor = "Green";
        }
        else if(looper>3)
        {
            posi = 1;
            currentColor = "Yellow";
        }
        else
        {
            posi = 0;
            currentColor = "Red";
        }

        if(currentColor != oldColor)
        {
            SetColor(currentColor, posi);
            Debug.Log($"The colour is {currentColor}");
            oldColor = currentColor;
        }

    }
}
