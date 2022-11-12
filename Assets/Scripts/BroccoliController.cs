using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BroccoliController : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private RaycastHit2D hit;

    [SerializeField]
    private GameObject bulletPrefab;

    private bool canFire = true;
    private float cooldownTime = 1f;
    float shootTimer;
    float shootCooldown = 200f;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void FixedUpdate()
    {

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        float scale = this.transform.localScale.x;

        moveDelta = new Vector3(x * 3, y * 3, 0);

        // flip sprite direction
        //if (moveDelta.x > 0)
        //{
        //    gameObject.transform.localScale = Vector3.one * scale;
        //}
        //else if (moveDelta.x < 0)
        //{
        //    gameObject.transform.localScale = new Vector3(-1 * scale, scale, scale);
        //}

        // check if there is a blocking wall in the y direction
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0,
                        new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime),
                        LayerMask.GetMask("Player", "Blocking"));

        if (hit.collider == null)
        {
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }

        // check if there is a blocking wall in the x direction
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0,
                        new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime),
                        LayerMask.GetMask("Player", "Blocking"));
        if (hit.collider == null)
        {
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }

        if (!canFire)
        {
            shootTimer += Time.deltaTime;
            if (shootTimer < shootCooldown)
            {
                canFire = true;
            }
        }

        if (Input.GetKey(KeyCode.Space) && canFire)
        {
            Fire();
            shootTimer = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(this);
            Debug.Log("Destroyed");
        }
        Debug.Log("Collision");

    }

    void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet.GetComponent<Bullet>().SetMoveDirection(new Vector2(1, 0).normalized);
        canFire = false;
        
    }

}
