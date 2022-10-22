using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    
    public float movementSpeed;
    public Rigidbody2D rb;

    public float jumpForce = 30f;
    public Transform feet;
    public LayerMask groundLayers;

    [HideInInspector] public bool isFacingRight = true;

    float mx;

    private void Update()
    {
        mx = Input.GetAxisRaw("Horizontal");

        if ((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && IsGrounded())
        {
            Jump();
        }

        //if (Mathf.Abs(mx) > 0.05f)
        //{
        //    anim.SetBool("isRunning", true);
        //}
        //else
        //{
        //    anim.SetBool("isRunning", false);
        //}

        if (mx > 0f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            isFacingRight = true;
        }
        else if (mx < 0f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            isFacingRight = false;
        }

        //anim.SetBool("isGrounded", IsGrounded());

        //if (Input.GetKeyDown(restart) && canRestart == true)
        //{
        //    Destroy(gameObject);
        //    LevelManager.instance.Respawn();
        //    LevelManager.instance.Restart();
        //    canRestart = false;
        //}
    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(mx * movementSpeed, rb.velocity.y);
        rb.velocity = movement;
    }

    void Jump()
    {
        Vector2 movement = new Vector2(rb.velocity.x, jumpForce);

        rb.velocity = movement;

        //jumpAudio.PlayOneShot(jumpAudio.clip, volume);

    }

    public bool IsGrounded()
    {
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.5f, groundLayers);

        if (groundCheck != null)
        {
            return true;
        }
        return false;

    }

   //public void OnTriggerEnter2D(Collider2D collider)
   //{
   //     Debug.Log("Test");
  // }

    

}
