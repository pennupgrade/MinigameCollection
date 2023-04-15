using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float SurvivalTime;
    public bool TimerOn = false;

    public Text TimerTxt;
   
    void Start()
    {
        TimerOn = true;
    }

    void Update()
    {
        if(TimerOn)
        {
            SurvivalTime += Time.deltaTime;
            updateTime(SurvivalTime);
        }
    }

    void updateTime(float currentTime)
    {

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        TimerTxt.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void endTimer() {
        TimerOn = false;
    }

}
