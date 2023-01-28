using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrookMovement : MonoBehaviour
{
    private float movementSpd = 5f;

    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.position += new Vector3(0, movementSpd * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.position += new Vector3(-movementSpd * Time.deltaTime, 0, 0);
            this.spriteRenderer.flipX = false;
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.position += new Vector3(0, -movementSpd * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.position += new Vector3(movementSpd * Time.deltaTime, 0, 0);
            this.spriteRenderer.flipX = true;
        }
    }
}
