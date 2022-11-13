using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : Shakeable
{
    
    [Header("Tower Settings")]
    private float nextShootTime = 0f;
    public float shootDelay = 1f;
    public float damage = 50f;
    
    public int speedCost = 5;
    public int damageCost = 5;


    private LineRenderer line;

    // Declare and initialize a new List of GameObjects called currentCollisions.
    private List<GameObject> currentCollisions;
    
    void OnTriggerEnter(Collider col)
    {
        // Add the GameObject collided with to the list.
        currentCollisions.Add (col.gameObject);
    }

    void OnTriggerExit(Collider col)
    {

        // Remove the GameObject collided with from the list.
        currentCollisions.Remove (col.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        currentCollisions = new List <GameObject> ();
        GetComponent<Renderer>().material.color = Color.green;
        line = GetComponent<LineRenderer>();

        // set width of the renderer
        line.startWidth = 0.05f;
        line.endWidth = 0.05f;
        
        line.SetPosition(0, transform.position);
        line.enabled = false;
    }

    bool AttemptShootEnemy()
    {
        //Debug.Log("trying to shoot");
        for (int i = 0; i < currentCollisions.Count; i++)
        {
            if (currentCollisions[i] == null)
            {
                currentCollisions.Remove(currentCollisions[i]);
                i --;
            }
            else
            {
                Enemy e = currentCollisions[i].GetComponent<Enemy>();
                if (e != null) {
                    
                    //enemy shoot animation here
                    GetComponent<Renderer>().material.color = Color.red;
            
                    // set the position
                    line.SetPosition(1, currentCollisions[i].transform.position);
                    line.enabled = true;

                    e.Damage(damage);
                    BeginShake();
                    
                    return true;
                }
            }
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextShootTime)
        {
            if (AttemptShootEnemy())
            {
                nextShootTime = Time.time + shootDelay;
            }
            
            
        }
        if (Time.time > nextShootTime - 0.5f) { // super placeholder colors
            GetComponent<Renderer>().material.color = Color.green;
            line.enabled = false;
        }
    }
}
