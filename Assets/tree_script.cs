using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random=UnityEngine.Random;

public class tree_script : MonoBehaviour
{
    Rigidbody body;
    // Start is called before the first frame update

    private SpriteRenderer spriteRenderer;

    public Sprite branch1;
    public Sprite branch2;
    public Sprite branch3;
    public Sprite branch4;
    public Sprite root1;
    public Sprite root2;
    public Sprite root3;

    private int ranB = 0;
    private int ranR = 0;

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        ranB = Random.Range(0, 4);
        ranR = Random.Range(0, 3);
    }

    // Update is called once per frame
    void Update()
    {

        var pcopy = transform.position;

        pcopy.x -= Manager.velocityX * Time.deltaTime;

        transform.position = pcopy;

        if (pcopy.x < -12 || (Manager.gameOver && pcopy.x > 10))
            Destroy(this.gameObject);

        var yPos = transform.position.y;
        if (yPos > 0.0f)
        {
            switch (ranB) {
                case 0: 
                    spriteRenderer.sprite = branch1;
                    break;
                case 1: 
                    spriteRenderer.sprite = branch2;
                    break;
                case 2: 
                    spriteRenderer.sprite = branch3;
                    break;
                case 3: 
                    spriteRenderer.sprite = branch4;
                    break;
            }
            
        } else {            
            switch (ranB) {
                case 0: 
                    spriteRenderer.sprite = root1;
                    break;
                case 1: 
                    spriteRenderer.sprite = root2;
                    break;
                case 2: 
                    spriteRenderer.sprite = root3;
                    break;
            }

        }
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
