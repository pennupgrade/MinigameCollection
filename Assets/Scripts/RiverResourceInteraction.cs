using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverResourceInteraction : MonoBehaviour
{
    bool waterBoxInRange = false;
    bool seedBoxInRange = false;
    bool soilInRange = false;

    GameObject waterBox;
    GameObject seedBox;
    GameObject soil;

    int amountWaterHeld = 0;
    int amountSeedsHeld = 0;

    void Start()
    {
        waterBox = GameObject.Find("Water Box");
        seedBox = GameObject.Find("Seed Box");
    }

    void Update()
    {
        if (seedBoxInRange && Input.GetKeyDown(KeyCode.Slash)) {
            amountSeedsHeld += seedBox.GetComponent<SeedBoxBehavior>().CollectSeeds();
        }
        
        if (waterBoxInRange && Input.GetKeyDown(KeyCode.Slash)) {
            amountWaterHeld += waterBox.GetComponent<WaterBoxBehavior>().CollectWater();
        }

        if (soilInRange && Input.GetKeyDown(KeyCode.Period)) {
            amountSeedsHeld = soil.GetComponent<SoilBehavior>().Seed(amountSeedsHeld);
            amountWaterHeld = soil.GetComponent<SoilBehavior>().Water(amountWaterHeld);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == waterBox) {
            waterBoxInRange = true;
        }

        if (other.gameObject == seedBox) {
            seedBoxInRange = true;
        }

        if (other.gameObject.tag.Equals("Soil")) {
            soilInRange = true;
            soil = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == waterBox) {
            waterBoxInRange = false;
        }

        if (other.gameObject == seedBox) {
            seedBoxInRange = false;
        }

        if (other.gameObject.tag.Equals("Soil")) {
            soilInRange = false;
            soil = null;
        }
    }

}
