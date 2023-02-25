using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    
    private Vector3 mvtVector;

    // controls how fast the enemy moves
    private float mvtSpd = 0.5f;

    // controls number of frames between enemy change in direction
    private int randomInterval = 120;

    // enemy changes direction by [-degreeOffsetBound, degreeOffsetBound]
    private float degreeOffsetBound = 45f;

    private int timer = 0;

    // target position vector
    private Vector3 target;

    void Start() {
        target = new Vector3(0, 0, 0);
        mvtVector = VectorToTarget() * mvtSpd;
    }

    void Update() {
        if (timer % randomInterval == 0) {
            RandomizeMovement();
        }

        transform.Translate(mvtVector * Time.deltaTime);

        timer++;
    }

    private Vector3 VectorToTarget() {
        return Vector3.Normalize(new Vector3(target.x - transform.position.x,
                                             target.y - transform.position.y,
                                             target.z - transform.position.z));
    }
    
    public void RandomizeMovement() {
        float degreeOffset = Random.Range(-degreeOffsetBound, degreeOffsetBound);
        float radianOffset = degreeOffset * Mathf.PI / 180f;

        Vector3 vectorToTarget = VectorToTarget();
        
        float newMvtVectorX = vectorToTarget.x * Mathf.Cos(radianOffset) -
                              vectorToTarget.y * Mathf.Sin(radianOffset);

        float newMvtVectorY = vectorToTarget.x * Mathf.Sin(radianOffset) +
                              vectorToTarget.y * Mathf.Cos(radianOffset);
        
        mvtVector = Vector3.Normalize(new Vector3(newMvtVectorX, 
                                                  newMvtVectorY, 
                                                  mvtVector.z)) * mvtSpd;
    }

}
