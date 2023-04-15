using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using UnityEngine;

public class player_script1 : MonoBehaviour
{

    Rigidbody2D body;
    BoxCollider2D boxc;
    public float gravity;
    Vector3 velocity;

    public float deathVelocityY;
    public float flyFactor;

    public float rotation;

    // Start is called before the first frame update
    void Start()
    {  
       body = GetComponent<Rigidbody2D>();
       boxc = GetComponent<BoxCollider2D>();
    }
    
    float holdTime;
    bool justDied;
    // Update is called once per frame
    void Update()
    {

        move();
        if (Manager.gameOver)
        {
            if (!justDied)
                velocity = new Vector3(0, deathVelocityY * Time.deltaTime, 0);
            justDied = true;
            transform.Rotate(0, 0, rotation);
            var vcopy = velocity;
            vcopy.x = 0.02f;
            velocity = vcopy;
            return;
        }
        else
            clamp();

    }
    public float timeToMaxVelocity;

    public float down;

    void move()
    {

        var vcopy = velocity;

        if (!Manager.gameOver)
        {

            if (Input.GetKey(KeyCode.W)) 
            {
                //holdTime += Time.deltaTime;
                //var addV = Interpolation.smooth.Apply(saveY, flyFactor * gravity, Math.Min(1, holdTime / timeToMaxVelocity));
                vcopy.y = 7f * Time.deltaTime;
            }
            else
            {
                vcopy.y -= gravity * Time.deltaTime;
            }
        }
        else
        {
            vcopy.y -= gravity * Time.deltaTime;
        }

        velocity = vcopy;
        transform.position = transform.position + velocity;
    }

    void clamp()
    {
        var copy = transform.position;

        var start = -4;

        if (copy.y - transform.localScale.y / 2 < start)
        {
            copy.y = start + transform.localScale.y / 2;
            velocity = new Vector3(0, 0, 0);
        }

        var end = 5;
        if (copy.y + transform.localScale.y / 2 > end)
        {
            copy.y = end - transform.localScale.y / 2;
            velocity = new Vector3(0, 0, 0);
        }
        transform.position = copy;
    }

}
