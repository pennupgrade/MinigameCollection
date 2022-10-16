using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Shakeable
{

    [Header("Enemy Settings")]

    [Range(0f, 2f)]
    public float fadeAwayTime = 0.5f;

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float maxHealth;

    private float health;

    

    private int waypointIndex = 0;
    private List<Transform> waypoints;

    public List<Transform> Waypoints
    {
        get { return waypoints; }
        set { waypoints = value; }

    }

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        GetComponent<SpriteRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
    }


    public void Damage(float amt)
    {

        if (health > 0)
        {
            this.BeginShake();
            health -= amt;
        }
    }

    private bool shouldDelete = false;

    // Update is called once per frame
    void Update()
    {
        // if all the death animations and stuff have completed, clean up the guy
        if (shouldDelete == true)
        {
            Destroy(this.gameObject);
        }
        // == kill enemy when health depleted
        else if (health <= 0)
        {
            // play death animation or something

            // for now just fading out
            Color c = gameObject.GetComponent<Renderer>().material.color;
            gameObject.GetComponent<Renderer>().material.color = new Color(c.r, c.g, c.b, c.a - Time.deltaTime / fadeAwayTime); // fades away in half a second

            if (gameObject.GetComponent<Renderer>().material.color.a <= 0) 
                shouldDelete = true;
        }
        // == movement along path
        // stolen from https://www.youtube.com/watch?v=KoFDDp5W5p0 if you were curious 
        else if (waypointIndex < waypoints.Count)
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


        // TESTING
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Damage(10);
        }

    }
}