using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Manager : MonoBehaviour
{
    public TMP_Text scoreT;
    public TMP_Text scoreUnder;
    public TMP_Text overT;

    public static bool gameOver = false;
    public static float score;
    public static float velocityX;

    public static void start()
    {
        score = 0;
        gameOver = false;
    }

    public float increaseSpeed;
    public float decreaseFactor;
    float decreaseSpeed;
    bool justDied;

    public float logScale;

    float timer;

    float rotation = 360f * 3;

    void Update()
    {
        if (!gameOver) 
        {
        
            overT.enabled = false;
            score += Time.deltaTime;
            scoreT.text = "" + (int)(score * 10);
            //velocityX += Time.deltaTime * increaseSpeed;

            velocityX = increaseSpeed * Mathf.Log(1 + score, logScale) / 2;
        }
        else
        {
            if (!justDied)
            {
                decreaseSpeed = velocityX * decreaseFactor;
                justDied = true;
            }
            scoreT.enabled = false;
            scoreUnder.enabled = false;
            overT.enabled = true;

            var copy = overT.transform.eulerAngles;

            copy.z = Interpolation.elasticOut.Apply(0, rotation, Math.Min(timer / 6f, 1));

            overT.transform.eulerAngles = copy;

            timer += Time.deltaTime;

            var a = Interpolation.elasticOut.Apply(0, 1, Math.Min(timer / 5f, 1));

            overT.transform.localScale = new Vector3(a, a, 1);

            velocityX -= Time.deltaTime * decreaseSpeed;
            if (velocityX < 0)
                velocityX = 0;
        }
        
    }


}
