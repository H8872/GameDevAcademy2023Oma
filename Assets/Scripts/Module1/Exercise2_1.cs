using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exercise2_1 : MonoBehaviour
{
    public float SaunaTemp;
    float seed;

    public GameObject Pointer;

    // Start is called before the first frame update
    void Start()
    {
        seed = SaunaTemp;
    }

    bool isChanged;
    // Update is called once per frame
    void Update()
    {
        SaunaTemp = Mathf.PerlinNoise(Time.time/20f,Mathf.Sin(seed))*145-5;

        Pointer.transform.localRotation = Quaternion.Euler(SaunaTemp/20*30-30,0,0);
        
        string response = "Tuloo vilu :/";
        if(SaunaTemp>=120)  response="prkl";
        else if(SaunaTemp>=100)  response="Ovi auki! D:";
        else if(SaunaTemp>=80)  response="Vihta keli!";
        else if(SaunaTemp>=60)  response="Sauna on pi päällä.";
        else if(SaunaTemp>=40)  response="Ei ainakaa kylymä";
        else if(SaunaTemp>=20)  response="Pitääs vissiin pistää ensi päälle";
        Debug.Log(response);
    }
}
