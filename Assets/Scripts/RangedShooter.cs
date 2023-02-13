using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedShooter : MonoBehaviour
{
    public Transform enemy;
    public Transform shotPoint;
    public Transform gun;

    public GameObject projectile;

    public float attackRange;

    public float startTimeBtwnShots;
    private float timeBtwnShots;

    // Update is called once per frame
    void Update()
    {
        Vector3 difference = enemy.position - gun.transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        gun.transform.rotation = Quaternion.Euler(0f, 0f, rotZ);

        if (Vector2.Distance(transform.position, enemy.position) <= attackRange)
        {
            if (timeBtwnShots <= 0)
            {
                Instantiate(projectile, shotPoint.position, shotPoint.transform.rotation);
                timeBtwnShots = startTimeBtwnShots;
            }
            else
            {
                timeBtwnShots -= Time.deltaTime;
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
