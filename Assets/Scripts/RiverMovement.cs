using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverMovement : MonoBehaviour
{
    private float movementSpd = 5f;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.position += new Vector3(0, movementSpd * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.position += new Vector3(-movementSpd * Time.deltaTime, 0);
            this.spriteRenderer.flipX = false;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.position += new Vector3(0, -movementSpd * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.position += new Vector3(movementSpd * Time.deltaTime, 0, 0);
            this.spriteRenderer.flipX = true;
        }
    }
}
