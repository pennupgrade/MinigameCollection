using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedStorageBehavior : MonoBehaviour
{

    private int remainingLRSeeds; // remaining long-range seeds
    private int remainingSRSeeds; // remaining short-range seeds

    // Start is called before the first frame update
    void Start()
    {
        remainingLRSeeds = 100;
        remainingSRSeeds = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void getLRSeeds() 
    {
        if (remainingLRSeeds > 0) 
        {
            remainingLRSeeds -= 1;
        }
    }

    void getSRSeeds()
    {
        if (remainingSRSeeds > 0) 
        {
            remainingSRSeeds -= 1;
        }
    }

    void refillLRSeeds() 
    {
        if (remainingLRSeeds < 100) 
        {
            remainingLRSeeds += 1;
        }
    }

    void getSRSeeds() 
    {
        if (remainingSRSeeds < 100) 
        {
            remainingSRSeeds += 1;
        }
    }
}
