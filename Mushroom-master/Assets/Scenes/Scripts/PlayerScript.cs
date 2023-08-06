using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private float health = 50;
    private float attack = 1;
    private float velocity = 16;
    public float jumpForce = 30 ;
    private float damageForce = 10;
    public float dashForce = 30;
    private float fallMultiplier = 1.5f;
    private float lowJumpMultiplier = 8f;
    private float recoilMultiplier = 10;
    private bool jumpState = false;
    private float gravity = 5;
    private float dir = 1;
    private float attackDir = 0;
    private bool isDashing = false;
    private bool onGround = false;
    private bool canDoubleJump = true;
    private bool canInput = true;
    private bool canAttack = true;
    private bool canDash = true;

    private Rigidbody2D body;
    private BoxCollider2D hitbox;
    private BoxCollider2D collider;
    public Animator animator;
    public GameManager gameManager;

    public GameObject playerAttack;

    public bool getIsDashing()
    {
        return isDashing;
    }

    IEnumerator waitDash(float time)
    {
        yield return new WaitForSeconds(time);

        canInput = true;
        body.gravityScale = gravity;
        body.velocity = Vector3.zero;
        hitbox.enabled = true;
        isDashing = false;
        this.transform.localScale = new Vector3(1, 1, 1);
    }

    IEnumerator dashCD(float time)
    {
        yield return new WaitForSeconds(time);
        canDash = true;
    }

    IEnumerator waitAttackInput(float time)
    {
        yield return new WaitForSeconds(time);
        canInput = true;
        animator.SetBool("attackUp", false);
        animator.SetBool("attackDown", false);
        animator.SetBool("attackHorizontal", false);
    }

    IEnumerator waitAttackCooldown(float time)
    {
        yield return new WaitForSeconds(time);
        canAttack = true;
    }

    public float getHealth()
    {
        return health;
    }

    public void setHealth(float newHealth)
    {
        health = newHealth;
    }

    IEnumerator recoverInputHit(float time)
    {
        yield return new WaitForSeconds(time);

        canInput = true;
    }

    IEnumerator recoverHitboxHit(float time)
    {
        yield return new WaitForSeconds(time);

        hitbox.enabled = true;
    }

    IEnumerator waitColor(float time)
    {
        yield return new WaitForSeconds(time);

        this.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
    }

    public void getHit(float damage)
    {
        health -= damage;
        body.AddForce(Vector3.up * damageForce, ForceMode2D.Impulse);
        canInput = false;
        hitbox.enabled = false;
        this.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1, 0.2f, 0.2f);
        if (health <= 0)
        {
            StartCoroutine(waitColor(0.2f));
            die();
        }
        else
        {
            StartCoroutine(recoverInputHit(0.35f));
            StartCoroutine(recoverHitboxHit(1f));
            StartCoroutine(waitColor(0.2f));
        }
    }

    void recoil()
    {
        body.velocity = Vector3.zero;

        if (attackDir == -2)
        {
            body.AddForce(Vector3.up * recoilMultiplier, ForceMode2D.Impulse);
        }
        else if (attackDir == 2)
        {
            body.AddForce(Vector3.up * -recoilMultiplier, ForceMode2D.Impulse);
        }
        else if (attackDir == 1)
        {
            body.AddForce((Vector3.left + new Vector3(1.2f, 0, 0)) * recoilMultiplier, ForceMode2D.Impulse);
        }
        else if (attackDir == -1)
        {
            body.AddForce((Vector3.left + new Vector3(1.2f, 0, 0)) * -recoilMultiplier, ForceMode2D.Impulse);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        hitbox = this.gameObject.transform.GetChild(1).GetComponent<BoxCollider2D>();
        body = this.GetComponent<Rigidbody2D>();
        collider = this.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (canInput)
        {
            this.transform.position += new Vector3(horizontalInput * velocity * Time.deltaTime, 0, 0);
            if (horizontalInput > 0)
            {
                this.transform.localScale = new Vector3(1, 1, 1);
                animator.SetBool("running", true);
            } else if (horizontalInput < 0)
            {
                this.transform.localScale = new Vector3(-1, 1, 1);
                animator.SetBool("running", true);
            } else
            {
                animator.SetBool("running", false);
            }
        }
        if (health <= 0)
        {
            die();
        }
        if (!isDashing)
        {
            if (Input.GetKey(KeyCode.C))
            {
                body.AddForce(Vector3.up * (-gravity * (fallMultiplier - 1) * Time.deltaTime), ForceMode2D.Impulse);
            }
            else
            {
                body.AddForce(Vector3.up * (-gravity * (lowJumpMultiplier - 1) * Time.deltaTime), ForceMode2D.Impulse);
            }
        }
    }

    void die()
    {
        canInput = false;
        animator.SetBool("die", true);
        gameManager.EndGame();

    }

    void Update()
    {
        if(body.position.y < -15)
        {
            animator.SetBool("die", true);
            die();
        }
        if (body.velocity.y < 0)
        {
            animator.SetInteger("rising", -1);
        }
        else if (body.velocity.y > 0)
        {
            animator.SetInteger("rising", 1);
        } else
        {
            animator.SetInteger("rising", 0);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            dir = 1;
            attackDir = 1;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            dir = -1;
            attackDir = -1;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            attackDir = 2;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            attackDir = -2;
        }
        if (canInput)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                if (onGround)
                {
                    body.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
                    jumpState = true;
                }
                else
                {
                    if (canDoubleJump && !jumpState)
                    {
                        body.velocity = Vector3.zero;
                        body.AddForce(Vector3.up * (jumpForce * 0.8f), ForceMode2D.Impulse);
                        canDoubleJump = false;
                    }
                }
            }
            else if (Input.GetKeyUp(KeyCode.C))
            {
                jumpState = false;
            }
            if (Input.GetKeyDown(KeyCode.X))
            {
                if (canDash)
                {
                    dash();
                }
            }
            if (Input.GetKeyDown(KeyCode.Z))
            {
                if (canAttack)
                {
                    if (attackDir == -2 && !onGround)
                    {
                        // DOWN DIRECTION
                        GameObject attack1 = Instantiate(playerAttack, this.gameObject.transform);
                        attack1.transform.position += new Vector3(0, -collider.bounds.extents.y - 1f, 0);
                        attack1.transform.Rotate(0, 0, 180);
                        recoil();
                        animator.SetBool("attackDown", true);
                        canInput = false;
                        canAttack = false;
                        StartCoroutine(waitAttackInput(0.3f));
                        StartCoroutine(waitAttackCooldown(0.7f));
                    }
                    else if (attackDir != -2)
                    {
                        GameObject attack1 = Instantiate(playerAttack);
                        attack1.transform.position = transform.position;
                        if (attackDir == 1)
                        {
                            attack1.gameObject.transform.position += new Vector3(-collider.bounds.extents.x - 1.7f, 0.1f, 0);
                            attack1.transform.Rotate(0, 0, 90);
                            recoil();
                            animator.SetBool("attackHorizontal", true);

                        }
                        if (attackDir == -1)
                        {
                            attack1.gameObject.transform.position += new Vector3(collider.bounds.extents.x + 1.7f, 0.1f, 0);
                            attack1.transform.Rotate(0, 0, 270); 
                            recoil();
                            animator.SetBool("attackHorizontal", true);

                        }
                        if (attackDir == 2)
                        {
                            if (dir == 1)
                            {
                                attack1.gameObject.transform.position += new Vector3(-0.5f, collider.bounds.extents.y + 1.4f, 0);
                            } else
                            {
                                attack1.gameObject.transform.position += new Vector3(0.5f, collider.bounds.extents.y + 1.4f, 0);
                            }
                            recoil();
                            animator.SetBool("attackUp", true);
                        }
                        canInput = false;
                        canAttack = false;
                        StartCoroutine(waitAttackInput(0.3f));
                        StartCoroutine(waitAttackCooldown(0.7f));
                    }
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.tag == "floor")
        {
            onGround = true;
            canDoubleJump = true;
            canDash = true;
        }
    }

    void OnCollisionExit2D(Collision2D hit)
    {
        if (hit.gameObject.tag == "floor")
        {
            onGround = false;
        }
    }

    void OnCollisionStay2D(Collision2D hit)
    {
        if (hit.gameObject.tag == "floor")
        {
            onGround = true;
            canDoubleJump = true;
            canDash = true;
            animator.SetInteger("rising", 0);
        }
    }

    void dash()
    {
        body.gravityScale = 0;
        body.velocity = Vector3.zero;
        hitbox.enabled = false;
        canInput = false;
        body.AddForce(Vector3.left * dir * dashForce, ForceMode2D.Impulse);
        isDashing = true;
        if (dir == 1)
        {
            this.transform.localScale = new Vector3(-1.5f, 0.7f, 1);
        } else
        {
            this.transform.localScale = new Vector3(1.5f, 0.7f, 1);
        }

        StartCoroutine(waitDash(0.25f));
        StartCoroutine(dashCD(1f));
        canDash = false;
    }
}
