using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float movementSpd = 1f;
    private float hp = 100f;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, 
                                                 new Vector3(0, 0, 0), 
                                                 Time.deltaTime * movementSpd);
    }
    
    public void ApplyDamage(float dmg)
    {
        hp -= dmg;
    }
}
