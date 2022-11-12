using System.Collections;
using System.Collections.Generic;
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

    // Start is called before the first frame update
    void Start()
    {
        sproutAnim = gameObject.GetComponent<Animator>();
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
    }


    private void Fire()
    {
        // should we do partial radial bullets or full 360?
        float angleStep = (endAngle - startAngle) / bulletsNum;
        float angle = startAngle;
        for (int i = 0; i < bulletsNum; i++)
        {
            float dirX = transform.position.x + Mathf.Sin(((angle + 180f * i) * Mathf.PI) / 180f);
            float dirY = transform.position.y + Mathf.Sin(((angle + 180f * i) * Mathf.PI) / 180f);

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

}