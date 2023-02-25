using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    Rigidbody2D body;
    public Enemy enemy;
    Animator animator;

    private float speed = 5f;
    private int damage = 5;


    void Start()
    {
        body = this.gameObject.GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 3f);
        Physics2D.IgnoreCollision(GameObject.FindWithTag("Player").GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
    }

    void Update()
    {
        transform.position += transform.right * Time.deltaTime * speed;
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
