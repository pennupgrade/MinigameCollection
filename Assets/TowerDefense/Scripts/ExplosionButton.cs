using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExplosionButton : MonoBehaviour
{

    public bool isSeeking;
    bool explosionActive;

    public Text label;
    public int cost;
    int lastCost;
    public int damage;

    public GameObject explosionRadiusObj;
    public LayerMask groundPlaneLayer;
    ExplosionRadius explosion;
    
    // Start is called before the first frame update
    void Start()
    {
        lastCost = cost;
        UpdateLabel();
        explosion = explosionRadiusObj.GetComponent<ExplosionRadius>();
    }

    void UpdateLabel()
    {
        if (isSeeking)
        {
            label.text = "Cancel";
        } else
        {
            label.text = "Air Strike (Cost: " + cost + ")";
        }
    }

    public void ToggleActive()
    {
        if (!isSeeking && GameManager.Instance.Money < cost)
            return;
        isSeeking = !isSeeking;
        UpdateLabel();
    }

    // Update is called once per frame
    void Update()
    {
        // ground plane detection code
        if (isSeeking) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            bool hasHit = Physics.Raycast(
                ray,
                out hit,
                100,
                groundPlaneLayer
            );
            if (hasHit)
            {
                explosionRadiusObj.SetActive(true);
                //Debug.Log(hit.point);
                explosionRadiusObj.transform.position = hit.point;
                if (Input.GetMouseButtonDown(0))
                {
                    GameManager.Instance.Money -= cost;
                    explosion.Damage(damage);
                    int c = cost;
                    cost += lastCost;
                    lastCost = c;
                    ToggleActive();
                }
            }
            else
            {
                explosionRadiusObj.SetActive(false);
            }

        }
        else if (!explosionActive)
        {
            explosionRadiusObj.SetActive(false);
        }
    }
}
