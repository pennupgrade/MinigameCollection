using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D body;
    Animator animator;
    GameObject playerBody;

    public int healthPoint = 10;

    public int damage = 10;

    public int speed = 3;

    public float attackSpeed = 1f;
    public float attackTime = 1f;

    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        body = this.gameObject.GetComponent<Rigidbody2D>();
        playerBody = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Swarm();
        if (healthPoint <= 0) {
            Destroy(this.gameObject);
        }
    }

    private void Swarm() {
        body.velocity = new Vector2(0,0);
        transform.position = Vector2.MoveTowards(transform.position, playerBody.transform.position, speed * Time.deltaTime);
        // body.velocity = Vector2.MoveTowards(body.velocity, playerBody.transform.position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision) {

        if(collision.gameObject.CompareTag("Player")) {
            collision.gameObject.GetComponent<Player>().takeDamage(damage);
        }
    }

    private void OnCollisionStay2D(Collision2D collision) {

        if(collision.gameObject.CompareTag("Player")) {
            if (attackTime <= 0) {
                collision.gameObject.GetComponent<Player>().takeDamage(damage);
                attackTime = 1f;
            } else {
                attackTime -= Time.deltaTime;
            }
        }
    }

    public void takeDamage(int damage) {
        healthPoint -= damage;
    }
}
