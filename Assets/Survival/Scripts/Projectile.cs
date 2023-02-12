using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    private float speed = 5f;

    void Start()
    {
        
    }

    private void Update()
    {
        transform.position += transform.right * Time.deltaTime * speed;
    }

    private void onCollision2D(onCollision2D)
    {
        Destroy(gameObject);
    }
}
