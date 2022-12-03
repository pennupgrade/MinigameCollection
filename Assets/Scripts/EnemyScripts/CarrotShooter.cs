using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class CarrotShooter : MonoBehaviour
{
    [SerializeField]
    private int bulletsNum = 1;

    [SerializeField]
    private float fireRate = 0.01f;

    [SerializeField]
    private float startAngle = 90f, endAngle = 180f;

    //[SerializeField]
    //private GameObject broccoli;

    private const float radius = 1F;

    private Vector2 direction;
    public GameObject ProjectilePrefab;         // Prefab to spawn.
    private Animator sproutAnim;
    private bool startShooting = false;

    public Vector2 test;
    public float speed;

    private float iterAngle;

    private Vector2 movementDirection;
    private Vector2 movementPerSecond;
    private float characterVelocity = 5f;
    private float latestDirectionChangeTime;
    private float directionChangeTime = 2f;

    private RaycastHit2D hit;
    private BoxCollider2D boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        sproutAnim = gameObject.GetComponent<Animator>();
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        iterAngle = 0;
    }

    void Update()
    {
        //if (Vector3.Distance(broccoli.transform.position, this.transform.position) < 100)
        if (Input.anyKey && !startShooting)
        {
            //sproutAnim.Play("CarrotSprout");
            InvokeRepeating("Fire", 1f, fireRate);
            startShooting = true;
        }
        if (startShooting && Time.time - latestDirectionChangeTime > directionChangeTime)
        {
            latestDirectionChangeTime = Time.time;
            calculateNewMovementVector();
            Debug.Log(movementDirection);
        }

        // check if there is a blocking wall in the y direction
        //hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0,
        //                new Vector2(0, movementPerSecond.y), Mathf.Abs(movementPerSecond.y * Time.deltaTime),
        //                LayerMask.GetMask("Player", "Blocking"));

        //if (hit.collider == null)
        //{
        //    transform.Translate(0, movementPerSecond.y * Time.deltaTime, 0);
        //}

        //// check if there is a blocking wall in the x direction
        //hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0,
        //                new Vector2(movementPerSecond.x, 0), Mathf.Abs(movementPerSecond.x * Time.deltaTime),
        //                LayerMask.GetMask("Player", "Blocking"));
        //if (hit.collider == null)
        //{
        //    transform.Translate(movementPerSecond.x * Time.deltaTime, 0, 0);
        //}

        //transform.position = new Vector2(transform.position.x + (movementPerSecond.x * Time.deltaTime), transform.position.y + (movementPerSecond.y * Time.deltaTime));
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPos.x > 0 && screenPos.x < Screen.width)
        {
            transform.Translate(movementPerSecond.x * Time.deltaTime, 0, 0);
        }
        if (screenPos.y > 0 && screenPos.y < Screen.height)
        {
            transform.Translate(0, movementPerSecond.y * Time.deltaTime, 0);
        } else
        {
            calculateNewMovementVector();
            latestDirectionChangeTime = 0;
        }

    }

    void calculateNewMovementVector()
    {
        movementDirection = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
        movementPerSecond = movementDirection * characterVelocity;
    }

    private void Fire()
    {
        // should we do partial radial bullets or full 360?
        float angleStep = (endAngle - startAngle) / bulletsNum;
        float angle = startAngle;
        iterAngle += 10;
        for (int i = 0; i < bulletsNum; i++)
        {
            float dirX = transform.position.x + Mathf.Sin(((iterAngle + angle + 180f * i) * Mathf.PI) / 180f);
            float dirY = transform.position.y + Mathf.Sin(((iterAngle + angle + 180f * i) * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(dirX, dirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bullet = BulletPool.bulletPoolInstance.GetBullet();
            bullet.transform.position = this.transform.position;
            bullet.transform.rotation = this.transform.rotation;
            bullet.SetActive(true);
            // negate dirX
            bullet.GetComponent<Bullet>().SetMoveDirection(new Vector2((float)-1.5, dirY).normalized);
            angle += angleStep;
        }
    }

    // make carrot shoot in a spiral
    private void spiralFire()
    {
        GameObject bullet = BulletPool.bulletPoolInstance.GetBullet();
        bullet.transform.position = this.transform.position;
        bullet.transform.rotation = this.transform.rotation;
        bullet.SetActive(true);

    }


}