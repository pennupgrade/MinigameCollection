using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tree_script : MonoBehaviour
{
    Rigidbody body;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        var pcopy = transform.position;

        pcopy.x -= Manager.velocityX * Time.deltaTime;

        transform.position = pcopy;

        if (pcopy.x < -12 || (Manager.gameOver && pcopy.x > 10))
            Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Tree touched something");
            Manager.gameOver = true;
        }

    }
}
