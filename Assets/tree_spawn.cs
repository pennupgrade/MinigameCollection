using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tree_spawn : MonoBehaviour
{

    public GameObject obstacle;
    private float timer;

    public float yPos;

    public float yOffset;

    public float spawnLow, spawnHigh;

    // Start is called before the first frame update
    void Start()
    {
        resetT();
    }

    float spawnT;
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > spawnT)
        {
            resetT();
            timer = 0;
            var s = Instantiate(obstacle);
            s.transform.position = new Vector3(11, yPos + yOffset * UnityEngine.Random.Range(-1, 1), 0);

        }
    }

    public void resetT()
    {
        spawnT = UnityEngine.Random.Range(spawnLow, spawnHigh);
    }
}
