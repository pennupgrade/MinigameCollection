using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float mvtSpd = 1f;
    private float hp = 100f;

    private int timer = 0;

    private int mvtInterval = 10;

    private float targetRadius = 2f;
    private Vector3 target;

    void Start() {
        target = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update() {
        if (timer % mvtInterval == 0) {
            randomizeTarget();
        }

        transform.position = Vector3.MoveTowards(transform.position, 
                                                 target, 
                                                 Time.deltaTime * mvtSpd);
        timer++;
    }
    
    public void randomizeTarget() {
        float x = targetRadius - Random.Range(0f, targetRadius);
        float y = targetRadius - x;

        if (Random.Range(0, 2) == 0) {
            target.x = Mathf.Sqrt(x);
        } else {
            target.x = -Mathf.Sqrt(x);
        }

        if (Random.Range(0, 2) == 0) {
            target.y = Mathf.Sqrt(y);
        } else {
            target.y = -Mathf.Sqrt(y);
        }
    }

    public void ApplyDamage(float dmg)
    {
        hp -= dmg;
    }
}
