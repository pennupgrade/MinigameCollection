using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D body;
    Animator animator;
    GameObject playerBody;
    public XP xp;


    public float healthPoint = 1f;

    public float damage = 0.05f;

    public int speed = 3;

    public float attackSpeed = 1f;
    public float attackTime = 1f;

    public Player player;

    void Start()
    {
        body = this.gameObject.GetComponent<Rigidbody2D>();
        playerBody = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        Swarm();
        if (healthPoint <= 0) {
            Instantiate(xp, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }

    private void Swarm() {
        body.velocity = new Vector2(0,0);
        if (playerBody.transform.position.x < transform.position.x) 
        {
            GetComponent<SpriteRenderer>().flipX = true;
        } else if (playerBody.transform.position.x > transform.position.x) 
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
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

    public void takeDamage(float damage) {
        healthPoint -= damage;
    }

    public void flashRed() {
        this.transform.GetComponent<SpriteRenderer>().color = new Color(1, 0.5f, 1);
        StartCoroutine(waitColor(0.2f));
    }
    
    //resets color
    IEnumerator waitColor(float time)
    {
        yield return new WaitForSeconds(time);
        this.transform.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
    }
}
