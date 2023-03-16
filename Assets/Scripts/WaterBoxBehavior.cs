using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBoxBehavior : MonoBehaviour
{
    static int maxWater = 100;
    int remainingWater = 100;

    void Update()
    {
        RefillWater();
    }

    public int CollectWater()
    {
        if (remainingWater > 0) {
            remainingWater--;
            return 1;
        }

        return 0;
    }

    void RefillWater()
    {
        if (remainingWater < maxWater) {
            remainingWater++;
        }
    }
}
