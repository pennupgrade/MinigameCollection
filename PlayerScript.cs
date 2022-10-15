using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private float health = 100;
    private float velocity = 8;
    public float jumpForce = 10;
    public float dashForce = 10;
    private float gravity = 5;
    private float dir = 1;
    private bool onGround = false;
    private bool canDoubleJump = true;
    private bool canDash = true;
    private bool canInput = true;

    private Rigidbody2D body;
    private BoxCollider2D hitbox;

    IEnumerator waitDash(float time)
    {
        yield return new WaitForSeconds(time);

        canInput = true;
        body.gravityScale = gravity;
        body.velocity = Vector3.zero;
    }

    float getHealth()
    {
        return health;
    }

    void setHealth(float newHealth)
    {
        health = newHealth;
    }

    // Start is called before the first frame update
    void Start()
    {
        body = this.GetComponent<Rigidbody2D>();
        hitbox = this.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (canInput)
        {
            this.transform.position += new Vector3(horizontalInput * velocity * Time.deltaTime, 0, 0);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            dir = 1;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            dir = -1;
        }
        if (canInput)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                if (onGround)
                {
                    body.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
                } else
                {
                    if (canDoubleJump)
                    {
                        body.velocity = Vector3.zero;
                        body.AddForce(Vector3.up * (jumpForce * 0.8f), ForceMode2D.Impulse);

                        canDoubleJump = false;
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.X))
            {
                if (canDash)
                {
                    dash();
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.tag == "Boss_Fight_Floor")
        {
            onGround = true;
            canDoubleJump = true;
            canDash = true;
        }
    }

    void OnCollisionExit2D(Collision2D hit)
    {
        if (hit.gameObject.tag == "Boss_Fight_Floor")
        {
            onGround = false;
        }
    }

    void OnCollisionStay2D(Collision2D hit)
    {
        if (hit.gameObject.tag == "Boss_Fight_Floor")
        {
            onGround = true;
            canDoubleJump = true;
            canDash = true;
        }
    }

    void dash()
    {
        body.gravityScale = 0;
        body.velocity = Vector3.zero;
        canInput = false;
        body.AddForce(Vector3.left * dir * dashForce, ForceMode2D.Impulse);

        StartCoroutine(waitDash(0.25f));
        canDash = false;
    }
}
