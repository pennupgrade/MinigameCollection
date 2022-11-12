using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float damage = 10;
    private float radius = 3;
    private float flyForce = 2;
    private Rigidbody2D body;
    private BoxCollider2D hitbox;
    public Vector3 targetPos;
    // Start is called before the first frame update
    void Start()
    {
        body = this.GetComponent<Rigidbody2D>();
        hitbox = this.GetComponent<BoxCollider2D>();
        Vector3 forceVec = new Vector3((targetPos.x - this.transform.position.x)/2, 3, 0);//this force still needs to be modified a little for best performance
        body.AddForce(forceVec * flyForce, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //cause damage around the sphere and explode
        //actual damage
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        float distanceToPlayer = Vector3.Distance(this.transform.position, player.transform.position);
        //print(distanceToPlayer);
        if (distanceToPlayer <= radius)
        {
            player.GetComponent<PlayerScript>().AddDamage(damage);
        }


        //visually explosion
        //play explosion animation


        //destroy the missile a little later
        Destroy(gameObject, 0.2f);
    }
}
