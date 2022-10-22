using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float damage = 10;
    public float radius = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //cause damage around the sphere and explode
        //actual damage
        float distanceToPlayer = gameObject.GetComponentInParent<Boss>().DistanceToPlayer;
        if (distanceToPlayer <= radius)
        {
            collision.collider.GetComponent<PlayerScript>().AddDamage(damage);
        }


        //visually explosion
        //play explosion animation
        Destroy(gameObject);
    }
}
