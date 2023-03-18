using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tree_spawn : MonoBehaviour
{

    public GameObject obstacle1;
    public GameObject obstacle2;

    private float timer;

    private float yPos = 4.2f;
    private float range = 1.6f;

    public float spawnLow, spawnHigh;

    private Boolean upBranch = false;

    // Start is called before the first frame update
    void Start()
    {
        if(UnityEngine.Random.Range(-1,1) < 0)
        {
            upBranch = true;
        }
        resetT();
    }

    float spawnT;
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > spawnT)
        {
            timer = 0;

            var m = obstacle1;
            yPos = 2.2f;

            if (upBranch)
            {
                m = obstacle2;
                yPos = -2.2f;
            }

            var s = Instantiate(m);
            s.transform.position = new Vector3(11, yPos + UnityEngine.Random.Range(-1 * range, range), 0);

            Debug.Log(yPos);

            resetT();
        }
    }

    public void resetT()
    {
        spawnT = UnityEngine.Random.Range(spawnLow, spawnHigh);
        upBranch = !upBranch;
    }
}