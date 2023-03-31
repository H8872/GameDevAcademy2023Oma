using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clockScript : MonoBehaviour
{
    public GameObject secondHand;
    public GameObject minuteHand;
    public GameObject hourHand;

    public float TimeSpeed;

    [SerializeField]
    float clockHours;
    [SerializeField]
    float clockMinutes;
    [SerializeField]
    float clockSeconds;
    
    float currentTime;
    bool timeCheck;
    float mtimer;
    float stimer;

    public GameObject pawn;
    public Light sun;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = clockSeconds+(clockMinutes*60)+(clockHours*60*60);
        Debug.Log("Starting time: " + clockHours + ":" + clockMinutes + ":" + clockSeconds);
        secondHand.transform.Rotate(new Vector3(0,360/60*clockSeconds,0));
        minuteHand.transform.Rotate(new Vector3(0,360/60*(clockMinutes+(clockSeconds/60)),0));
        hourHand.transform.Rotate(new Vector3(0,360/12*(clockHours+(clockMinutes/60)),0));
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = (currentTime + TimeSpeed * Time.deltaTime) % 43200;

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
        hourHand.transform.Rotate(new Vector3(0,360f/60f,0) * Time.deltaTime/60f/12f*TimeSpeed);

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

        sun.intensity = Mathf.Abs(Mathf.Sin(hourHand.transform.rotation.y));

    }

    public void SpinPawn(float speed)
    {
        speed = speed / 43200;
        pawn.GetComponent<Animator>().SetFloat("SpinSpeed", speed);
    }
}