using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilBehavior : MonoBehaviour
{
    bool seeded = false;
    bool watered = false;

    GameObject curPlant = null;

    public GameObject longRangedPlant;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (seeded && watered && curPlant == null) {
            seeded = false;
            watered = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Plant();
        }
    }

    public int Seed(int seeds) 
    {
        if (seeded || seeds <= 0 || curPlant != null) {
            return seeds;
        }

        seeded = true;
        return seeds - 1;
    }

    public int Water(int water) 
    {
        if (watered || water <= 0 || curPlant != null) {
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
    
    void Plant()
    {
        curPlant = Instantiate(longRangedPlant, transform.position, Quaternion.identity);
    }
}
