using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using UnityEngine;

public class player_script : MonoBehaviour
{

    Rigidbody2D body;
    float gravity = 0.1f;
    Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {  
       body = GetComponent<Rigidbody2D>();
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
                velocity = new Vector3(0, 30 * Time.deltaTime, 0);
            justDied = true;
            transform.Rotate(0, 0, 2);
            var vcopy = velocity;
            vcopy.x = 0.02f;
            velocity = vcopy;
            return;
        }
        else
            clamp();

    }

    void move()
    {
        if (Input.GetKey(KeyCode.W) && !Manager.gameOver)
        {
            holdTime += Time.deltaTime;
            velocity = velocity + new Vector3(0, Interpolation.smooth.Apply(0, 1.01f * gravity, Math.Max(1, holdTime / 4f)), 0);
        }
        else
        {
            holdTime = 0;
        }
        velocity = velocity + new Vector3(0, -gravity * Time.deltaTime, 0);
        var vcopy = velocity;
        var vymax = 0.03f;
        if (velocity.y > vymax)
            vcopy.y = vymax;
        velocity = vcopy;

        var copy = transform.position;

        copy = copy + velocity;


        transform.position = copy;
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
