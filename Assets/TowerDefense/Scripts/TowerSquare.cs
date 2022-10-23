using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSquare : MonoBehaviour
{

    private bool active = false;

    private bool mousedOver;

    public GameObject towerPrefab;

    private GameObject currentTower;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.color = new Color(1,1,1,0.5f);
    }

    void PurchaseTower() {

        if (GameManager.Instance.Money >= 10) {
            currentTower = Instantiate(towerPrefab, transform.position + Vector3.up, Quaternion.identity); 
            GameManager.Instance.Money -= 10; // placeholder price
            active = true;
            //GetComponent<Renderer>().enabled = false;
            //GetComponent<Renderer>().material.color = new Color(0,0,0,0.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("faoewjfwe");
            if(mousedOver)
            {
                Debug.Log("moused over click");
                if (active)
                {
                    Debug.Log("Active click");
                    GameManager.Instance.OpenTowerUpgradePanel(currentTower);
                }
                else
                {
                    PurchaseTower();
                }
            }
        }
    }
    
    void OnMouseOver()
    {
        mousedOver = true;
        GetComponent<Renderer>().material.color = new Color(1,1,1,0.3f);
    }

    void OnMouseExit()
    {
        mousedOver = false;
        GetComponent<Renderer>().material.color = active? new Color(1,1,1,0.5f) : new Color(1,1,1,0.0f);
        
    }
}
