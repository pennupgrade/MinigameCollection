using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveTimer : MonoBehaviour
{
    private Text timerText;
    private float time = 30f;
    private bool isRunning = true;

    void Start()
    {
        timerText = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning) {
            time -= Time.deltaTime;
            timerText.text = "Wave begins in " + Mathf.Ceil(time) + "...";
            
            if (time <= 0) {
                timerText.text = "";
                isRunning = false;
            }
        }
    }

    void Begin()
    {
        Reset();
        isRunning = true;
    }

    void Reset()
    {
        time = 30f;
    }
}
