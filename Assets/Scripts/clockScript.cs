using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clockScript : MonoBehaviour
{
    
    [SerializeField]
    public GameObject secondHand, minuteHand, hourHand;

    [SerializeField]
    float TimeSpeed, clockHours, clockMinutes, clockSeconds, currentTime;
    
    bool timeCheck;
    float mtimer, stimer, timeLenght;

    public GameObject pawn;
    public Light sun;

    // Start is called before the first frame update
    void Start()
    {
        timeLenght = 43200;
        currentTime = clockSeconds+(clockMinutes*60)+(clockHours*60*60);
        Debug.Log("Starting time: " + clockHours + ":" + clockMinutes + ":" + clockSeconds);
        secondHand.transform.Rotate(new Vector3(0,360/60*clockSeconds,0));
        minuteHand.transform.Rotate(new Vector3(0,360/60*(clockMinutes+(clockSeconds/60)),0));
        hourHand.transform.Rotate(new Vector3(0,360/12*(clockHours+(clockMinutes/60)),0));
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = (currentTime + TimeSpeed * Time.deltaTime) % (timeLenght*2);

        if(clockSeconds<Mathf.Floor(currentTime % 60))
        {
            stimer = Time.time;
            SpinPawn(currentTime);
        }
        else
        {
            float ts = (Time.time - stimer) / 0.1f;
            secondHand.transform.localRotation = Quaternion.Euler(0,Mathf.SmoothStep(6*clockSeconds-6,6*clockSeconds,ts),0);
        }

        clockHours = Mathf.Floor(currentTime/60/60);
        clockMinutes = Mathf.Floor((currentTime-clockHours*60*60)/60);
        clockSeconds = Mathf.Floor(currentTime % 60);
        //Debug.Log(currentTime  + " = " + clockHours + ":" + clockMinutes + ":" + clockSeconds);
        //secondHand.transform.Rotate(new Vector3(0,360f/60f,0) * Time.deltaTime*TimeSpeed);
        //minuteHand.transform.Rotate(new Vector3(0,360/60,0) * Time.deltaTime/60*TimeSpeed);
        //hourHand.transform.Rotate(new Vector3(0,360f/60f,0) * Time.deltaTime/60f/12f*TimeSpeed);


        if(clockSeconds == 0)
        {
            if(!timeCheck)
            {
                mtimer = Time.time;
                timeCheck = true;
            }
            float t = (Time.time - mtimer) / 0.1f;
            minuteHand.transform.localRotation = Quaternion.Euler(0,Mathf.SmoothStep(6*clockMinutes-6,6*clockMinutes,t),0);
        }
        else
        {
            timeCheck = false;
            minuteHand.transform.localRotation = Quaternion.Euler(0,6*clockMinutes,0);
        }

        hourHand.transform.localRotation = Quaternion.Euler(0,(currentTime % timeLenght)/timeLenght*360,0);
        //Debug.Log(currentTime);

        sun.intensity = 0.5f+(Mathf.Sin(((currentTime+(timeLenght/4f)) / timeLenght)*Mathf.PI)/2)*-1;
        Debug.Log(sun.intensity);
    }

    public void SpinPawn(float speed)
    {
        pawn.GetComponent<Animator>().SetFloat("SpinSpeed", speed / timeLenght);
    }
}