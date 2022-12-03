using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    public float moveSpeed = 5;
    public float timer = 0;
    public float maxTime;
    public int dir;
    public bool isBouncing = false;

    // Start is called before the first frame update
    void Start()
    {
        maxTime = Random.Range(1, 5);
        dir = 1;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= maxTime) {
            dir *= -1;
            timer = 0;
            Debug.Log("switching directions");
        }
        transform.Translate(new Vector2(dir, 0) * moveSpeed * Time.deltaTime);
        
    }

    public void bounceBack() {
        /*
        float bounce = 6f; //amount of force to apply
        rb.AddForce(bounce);
        isBouncing = true;
        Invoke("StopBounce", 0.3f);*/
    }

    void stopBounce() {
        isBouncing = false;
    }
}
