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