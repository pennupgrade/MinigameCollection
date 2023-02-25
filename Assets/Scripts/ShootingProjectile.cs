using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingProjectile : MonoBehaviour
{
    public float projectileSpeed;
    public float lifeTime;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }

    //Collision with enemy
    private void OnCollisionEnter2D (Collision2D collision)
    {
        //Enemies to take damage
        if (collision.transform.tag == "Enemy")
        {
            // do damage here, for example:
            collision.gameObject.GetComponent<EnemyHP>().TakeDamage(1);
        }

        Destroy(gameObject);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.right * projectileSpeed * Time.deltaTime);
    }

    void DestroyProjectile()
    {
        if (gameObject != null)
        {
            // Do something  
            Destroy(gameObject);
        }
    }
}