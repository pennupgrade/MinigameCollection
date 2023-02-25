using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D body;
    Animator animator;

    public Projectile projectilePrefab;
    public Transform launchOffset;

    private float moveSpeed = 20.0f;
    private Vector3 targetPos;
    public int healthPoint = 120;

    private float defaultReloadTime = 1;
    private float reloadTime = 1;
    private bool isAlive = true;

    private float horizontal;
    private float vertical;
    private float moveLimiter = 0.7f;

    void Start ()
    {
        body = this.gameObject.GetComponent<Rigidbody2D>();
        animator = this.gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (isAlive) {

            //reload
            if (reloadTime <= 0) {
                reloadTime = defaultReloadTime;
                Instantiate(projectilePrefab, launchOffset.position, transform.rotation);
            } else {
                reloadTime -= Time.deltaTime;
            }


            // Gives a value between -1 and 1
            horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
            vertical = Input.GetAxisRaw("Vertical"); // -1 is down

            //pauses animation if no inputs
            if (horizontal == 0 && vertical == 0)
            {
                animator.enabled = false;
            } else {
                animator.enabled = true;
            }
        }


    }

    void FixedUpdate()
    {
        if (isAlive)
        {
            // Check for diagonal movement
            if (horizontal != 0 && vertical != 0)
            {
                // limit movement speed diagonally, so you move at 70% speed
                horizontal *= moveLimiter;
                vertical *= moveLimiter;
            } 


            body.velocity = new Vector2(horizontal * moveSpeed, vertical * moveSpeed);
        }
    }

    public int getHealth() {
        return healthPoint;
    }

    public void takeDamage(int damage) {
        Debug.Log(healthPoint);
        healthPoint -= damage;
        if (healthPoint <= 0) {
            isAlive = false;
        }
    }
}
