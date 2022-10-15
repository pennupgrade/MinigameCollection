using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSquare : MonoBehaviour
{

    private bool active = false;

    private bool mousedOver;

    public GameObject tower;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.color = new Color(1,1,1,0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(mousedOver)
            {
                if (!active) {
                    Instantiate(tower);
                    active = true;
                    GetComponent<Renderer>().material.color = new Color(1,1,1,0.0f);
                }
            }
        }
    }
    void OnMouseOver()
    {
        mousedOver = true;
        // hacky color stuff for now
        if (!active) GetComponent<Renderer>().material.color = new Color(1,1,1,0.3f);
    }

    void OnMouseExit()
    {
        mousedOver = false;
        // hacky color stuff for now
        if (!active) GetComponent<Renderer>().material.color = new Color(1,1,1,0.5f);
    }
}
