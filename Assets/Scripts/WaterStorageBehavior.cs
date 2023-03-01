using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterStorageBehavior : MonoBehaviour
{
    private int remainingWater = 100;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void collectWater()
    {
        if (remainingWater > 0) {
            Debug.Log("water left in tank: " + remainingWater + "%");
            remainingWater -= 1;
        } else {
            Debug.Log("no water left!");
        }
    }

    void refillWater()
    {
        if (remainingWater < 100) {
            remainingWater += 1;
            Debug.Log("water left: " + remainingWater + "%");
        } else {
            Debug.Log("water tank is full!");
        }
    }
}
