using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotShooter : MonoBehaviour
{
    [SerializeField]
    private int bulletsNum = 10;

    [SerializeField]
    private float fireRate = 0.5f;

    [SerializeField]
    private float startAngle = 90f, endAngle = 180f;
    private const float radius = 1F;

    private Vector2 direction;
    public GameObject ProjectilePrefab;         // Prefab to spawn.

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", 0f, fireRate);
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


    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    SpawnProjectile(bulletsNum);
        //}
    }

    // Spawns x number of projectiles.
    //private void SpawnProjectile(int _numberOfProjectiles)
    //{
    //    float angleStep = 360f / _numberOfProjectiles;
    //    float angle = 0f;

    //    for (int i = 0; i <= _numberOfProjectiles - 1; i++)
    //    {
    //        // Direction calculations.
    //        float projectileDirXPosition = this.transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
    //        float projectileDirYPosition = this.transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

    //        // Create vectors.
    //        Vector3 projectileVector = new Vector3(projectileDirXPosition, projectileDirYPosition, 0);
    //        Vector3 projectileMoveDirection = (projectileVector - this.transform.position).normalized;

    //        // Create game objects.
    //        GameObject tmpObj = Instantiate(ProjectilePrefab, this.transform.position, Quaternion.identity);
    //        tmpObj.GetComponent<Rigidbody>().velocity = new Vector3(projectileMoveDirection.x, 0, projectileMoveDirection.y);

    //        // Destory the gameobject after 10 seconds.
    //        Destroy(tmpObj, 10F);

    //        angle += angleStep;
    //    }
    //}

}