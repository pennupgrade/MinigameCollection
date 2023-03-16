using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedBoxBehavior : MonoBehaviour
{
    static int maxSeeds = 100;
    int remainingSeeds = maxSeeds;

    void Update()
    {
        RefillSeeds();
    }

    public int CollectSeeds() 
    {
        if (remainingSeeds > 0) {
            remainingSeeds--;
            return 1;
        }

        return 0;
    }

    void RefillSeeds() 
    {
        if (remainingSeeds < maxSeeds) {
            remainingSeeds++;
        }
    }

}
