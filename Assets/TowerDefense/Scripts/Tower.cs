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
    public int prevSpeedCost;
    public int prevDamageCost;

    public void incSpeedCost()
    {
        int temp = speedCost;
        speedCost += prevSpeedCost;
        prevDamageCost = temp;
    }

    public void incDamageCost()
    {
        int temp = damageCost;
        damageCost += prevDamageCost;
        prevDamageCost = temp;
    }

    private float VOLUME = 0.3f;

    private LineRenderer line;

    private AudioSource audioSource;

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
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = VOLUME;
        prevDamageCost = damageCost;
        prevSpeedCost = speedCost;
        // set width of the renderer
        line.startWidth = 0.05f;
        line.endWidth = 0.05f;
        
        line.SetPosition(0, transform.position);
        line.enabled = false;
    }

    bool AttemptShootEnemy()
    {
        //Debug.Log("trying to shoot");
        Enemy toShoot = null;
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
                if (e != null && e.Health > 0) {
                    // prioritize farthest along enemy to shoot
                    toShoot = (toShoot == null || e.CompareTo(toShoot) > 0) ? e : toShoot;
                }
            }
        }

        if (toShoot != null)
        {
            //enemy shoot animation here
            GetComponent<Renderer>().material.color = Color.red;

            // set the position
            line.SetPosition(1, toShoot.gameObject.transform.position);
            line.enabled = true;

            toShoot.Damage(damage);
            audioSource.Play();
            BeginShake();
        }

        return toShoot != null;
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
        if (Time.time > nextShootTime - shootDelay + 0.1f) { // super placeholder colors
            GetComponent<Renderer>().material.color = Color.green;
            line.enabled = false;
        }
    }
}
