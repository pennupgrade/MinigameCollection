using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float maxHealth;

    private float health;


    private int waypointIndex = 0;
    public List<Transform> waypoints;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }


    void Damage(float amt)
    {
        health -= amt;
    }

    // Update is called once per frame
    void Update()
    {

        // == kill enemy when health depleted
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }

        // == movement along path
        // stolen from https://www.youtube.com/watch?v=KoFDDp5W5p0 if you were curious 
        if (waypointIndex < waypoints.Count)
        {
            
            // Move Enemy from current waypoint to the next one
            // using MoveTowards method
            transform.position = Vector3.MoveTowards(transform.position,
               waypoints[waypointIndex].transform.position,
               moveSpeed * Time.deltaTime);

            // If Enemy reaches position of waypoint he walked towards
            // then waypointIndex is increased by 1
            // and Enemy starts to walk to the next waypoint
            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex += 1;
            }

        }
        // reached end of path
        else 
        {
            // decrement game health
            GameManager.Instance.Health -= 1;
            Destroy(this.gameObject);
        }

    }
}