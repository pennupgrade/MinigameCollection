using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrookMovement : MonoBehaviour
{
    private enum Direction {UP, LEFT, DOWN, RIGHT};
    
    private float horizontalSpd;
    private float verticalSpd;

    private float minSpd = 2f;
    
    private float maxSpd = 5f;

    private float acceleration = 0.3f;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        horizontalSpd = minSpd;
        verticalSpd = minSpd;

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W)) {
            move(Direction.UP);
        }
        if (Input.GetKey(KeyCode.A)) {
            move(Direction.LEFT);
        }
        if (Input.GetKey(KeyCode.S)) {
            move(Direction.DOWN);
        }
        if (Input.GetKey(KeyCode.D)) {
            move(Direction.RIGHT);
        }
    }

    void move (Direction direction) {
        switch (direction) {
            case Direction.UP:
                if (verticalSpd < 0f) {
                    verticalSpd = minSpd;
                } else if (verticalSpd < maxSpd) {
                    verticalSpd += acceleration;
                }
                this.transform.Translate(0, verticalSpd * Time.deltaTime, 0);
                break;
            case Direction.LEFT:
                spriteRenderer.flipX = false;

                if (horizontalSpd > 0f) {
                    horizontalSpd = -minSpd;
                } else if (horizontalSpd > -maxSpd) {
                    horizontalSpd -= acceleration;
                }
                this.transform.Translate(horizontalSpd * Time.deltaTime, 0, 0);
                break;
            case Direction.DOWN:
                if (verticalSpd > 0f) {
                    verticalSpd = -minSpd;
                } else if (verticalSpd > -maxSpd) {
                    verticalSpd -= acceleration;
                }
                this.transform.Translate(0, verticalSpd * Time.deltaTime, 0);
                break;
            case Direction.RIGHT:
                spriteRenderer.flipX = true;

                if (horizontalSpd < 0f) {
                    horizontalSpd = minSpd;
                } else if (horizontalSpd < maxSpd) {
                    horizontalSpd += acceleration;
                }
                this.transform.Translate(horizontalSpd * Time.deltaTime, 0, 0);
                break;
        }
    }

}
