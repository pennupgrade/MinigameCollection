using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverWaterBoxInteraction : MonoBehaviour
{
    private bool inRange;
    public GameObject waterStorage;
    private int amountWaterHeld;

    // Start is called before the first frame update
    void Start()
    {
        inRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange) {
            if (Input.GetKeyDown(KeyCode.Slash)) {
                Debug.Log("player picking up water");
                waterStorage.GetComponent<WaterStorageBehavior>().collectWater();
                amountWaterHeld++;
                Debug.Log("player now has " + amountWaterHeld + " water"); 
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name.Equals("WaterBox")) {
            Debug.Log("player in range to pick up some water");
            inRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.name.Equals("WaterBox")) {
            Debug.Log("player not in range to pick up some water");
            inRange = false;
        }
    }
}
