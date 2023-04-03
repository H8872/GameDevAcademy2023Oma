using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class clockScript : MonoBehaviour
{

    public enum Mode{Instant, Smooth, CurveRealistic}

    public Mode clockMode = Mode.CurveRealistic;
    
    [SerializeField]
    GameObject secondHand, minuteHand, hourHand;

    [SerializeField]
    TextMeshPro digiFace;

    [SerializeField]
    float TimeSpeed, clockHours, clockMinutes, clockSeconds, startTime;
    float currentTime;

    [SerializeField]
    AnimationCurve curve;
    
    bool timeCheck;
    float mtimer, stimer, timeLenght;

    public GameObject pawn;
    public Light sun;

    // Start is called before the first frame update
    void Start()
    {
        timeLenght = 43200f;
        startTime = clockSeconds+(clockMinutes*60f)+(clockHours*60f*60f);
        Debug.Log("Starting time: " + clockHours + ":" + clockMinutes + ":" + clockSeconds);
        secondHand.transform.Rotate(new Vector3(0,360/60*clockSeconds,0));
        minuteHand.transform.Rotate(new Vector3(0,360/60*(clockMinutes+(clockSeconds/60)),0));
        hourHand.transform.Rotate(new Vector3(0,360/12*(clockHours+(clockMinutes/60)),0));
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = TimeSpeed;
        currentTime = (startTime + Time.time) % (timeLenght*2);
        if(clockSeconds>Mathf.Floor(currentTime % 60))
        {
            stimer = Time.time;
            SpinPawn(currentTime);
        }
        clockHours = Mathf.Floor(currentTime/60/60);
        clockMinutes = Mathf.Floor((currentTime-clockHours*60*60)/60);
        clockSeconds = Mathf.Floor(currentTime % 60);

        if(clockMode == Mode.CurveRealistic)
        {
            secondHand.transform.localRotation = Quaternion.Euler(0,curve.Evaluate(currentTime % 1)*6+clockSeconds*6,0);
        }
        else if(clockMode == Mode.Instant)
        {
            secondHand.transform.localRotation = Quaternion.Euler(0,6*clockSeconds,0);
        }
        else if(clockMode == Mode.Smooth)
        {
            float ts = Time.time -Mathf.Floor(Time.time);
            Debug.Log(ts);
            secondHand.transform.localRotation = Quaternion.Euler(0,Mathf.Lerp(clockSeconds*6, clockSeconds*6+6,ts),0);
        }
        else
        {
            Debug.LogError("Clock Mode Impossible :)");
        }

        



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
        //Debug.Log(sun.intensity);

        digiFace.text = clockHours.ToString("00")+":"+clockMinutes.ToString("00")+"\n"+clockSeconds.ToString("00");
    }

    public void SpinPawn(float speed)
    {
        pawn.GetComponent<Animator>().SetFloat("SpinSpeed", speed / timeLenght);
    }
}