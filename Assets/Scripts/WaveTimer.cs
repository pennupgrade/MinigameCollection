using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveTimer : MonoBehaviour
{
    Text timerText;
    WaveCounter waveCounter;
    GameObject[] respawns;

    float time = 30f;
    bool isRunning = true;

    // Start is called before the first frame update
    void Start()
    {
        timerText = gameObject.GetComponent<Text>();
        waveCounter = GameObject.Find("Wave Counter").GetComponent<WaveCounter>();
        respawns = GameObject.FindGameObjectsWithTag("Respawn");
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning) {
            time -= Time.deltaTime;
            timerText.text = "Wave begins in " + Mathf.Ceil(time) + "...";
            
            if (time <= 0) {
                End();
            }

        } else if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0) {
            Begin();
        }
    }

    public void Begin()
    {
        time = 30f;
        isRunning = true;
    }

    void End()
    {
        timerText.text = "";
        isRunning = false;

        int curWave = waveCounter.Increment();

        foreach (GameObject respawn in respawns) {
            respawn.GetComponent<Spawnpoint>().Begin(Random.Range(1, 1 + curWave));
        }
    }
}
