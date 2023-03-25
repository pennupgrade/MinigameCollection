using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    Rigidbody2D body;
    public Enemy enemy;

    private bool flip = false;
    private float speed = 5f;
    private float damage = 0.5f;


    void Start()
    {
        body = this.gameObject.GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 3f);
        Physics2D.IgnoreCollision(GameObject.FindWithTag("Player").GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
        transform.Rotate(Vector3.forward * -90);
        flip = GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>().flipX;
        if(flip) {
            transform.Rotate(Vector3.forward * 180);
        }
    }

    void Update()
    {
        transform.position += transform.up * Time.deltaTime * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy")) 
        {
            collision.gameObject.GetComponent<Enemy>().takeDamage(damage);
            Destroy(this.gameObject);
        }
    }

}
