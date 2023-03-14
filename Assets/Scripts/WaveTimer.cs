using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveTimer : MonoBehaviour
{
    Text timerText;
    GameObject waveCounter;

    float time = 30f;
    bool isRunning = true;

    // Start is called before the first frame update
    void Start()
    {
        timerText = gameObject.GetComponent<Text>();
        waveCounter = GameObject.Find("Wave Counter");
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

                waveCounter.GetComponent<WaveCounter>().Increment();
            }
        }
    }

    public void Begin()
    {
        Reset();
        isRunning = true;
    }

    void Reset()
    {
        time = 30f;
    }
}
