using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilBehavior : MonoBehaviour
{
    bool seeded = false;
    bool watered = false;
    bool planted = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (seeded && watered && !planted) {
            seeded = false;
            watered = false;
            planted = true;
        }
    }

    public int Seed(int seeds) 
    {
        if (seeded || seeds <= 0) {
            return seeds;
        }

        seeded = true;
        return seeds - 1;
    }

    public int Water(int water) 
    {
        if (watered || water <= 0) {
            return water;
        }

        watered = true;
        return water - 1;
    }

    public bool IsSeeded() 
    {
        return seeded;
    }

    public bool IsWatered() 
    {
        return watered;
    }
}
