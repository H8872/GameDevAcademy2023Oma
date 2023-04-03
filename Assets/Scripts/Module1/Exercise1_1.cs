using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exercise1_1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float a = 0f;
        float b = 0f;
        Debug.Log("Summa: " + (a+b));
        Debug.Log("Erotus: " + (a-b));
        Debug.Log("Kerto: " + (a*b));
        Debug.Log("Jako: " + (a/b)); // Becomes Infinity when b = 0 and Not a Number if both a and b = 0
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
