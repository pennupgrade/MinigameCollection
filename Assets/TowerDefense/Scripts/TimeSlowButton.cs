using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeSlowButton : MonoBehaviour
{
    // Start is called before the first frame update
    public Text label;
    public int cost;
    int lastCost;
    public float slowDuration = 5f;

    public AudioSource sound;

    // PLACEHOLDER JUST GOING TO SPAWN EVERY X SECONDS
    private float endSlowTime = 0.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        UpdateLabel();
        lastCost = cost;
    }

    void UpdateLabel()
    {
        if (GameManager.Instance.timeSlowed)
        {
            label.text = "Time slowed! (" + (endSlowTime - Time.time).ToString("F2") + "s)";
        } else
        {
            label.text = "Slow Time (Cost: " + cost + ")";
        }
    }

    public void SlowTime()
    {
        if (GameManager.Instance.Money < cost || Time.time <= endSlowTime)
            return;
        endSlowTime = Time.time + slowDuration;
        GameManager.Instance.timeSlowed = true;
        sound.Play();
        int c = cost;
        cost += lastCost;
        lastCost = c;
        UpdateLabel();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.timeSlowed && Time.time > endSlowTime)
        {
            GameManager.Instance.timeSlowed = false;
            UpdateLabel();
        }
        else if (Time.time <= endSlowTime)
        {
            UpdateLabel();
        }
    }
}

