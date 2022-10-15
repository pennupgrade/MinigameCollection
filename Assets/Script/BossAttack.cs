using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public GameObject laserPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void laserAttack1(int stage, Vector3 startPos, Vector3 playerPos) {//sweep style
        //initialize a laser prefab
        float degree = 45.0f;
        bool playerAtRight = false;
        if (stage > 1) {
            degree = 60.0f;
        }
        if (playerPos.x > startPos.x) {
            degree = -degree;
            playerAtRight = true;
        }
        //TODO position and degree
        Vector3 targetDir = playerAtRight ? playerPos - startPos : startPos - playerPos;
        Vector3 position = playerAtRight ? (playerPos - startPos)/2 + startPos:  (startPos - playerPos)/2 + playerPos;
        GameObject laser = Instantiate(laserPrefab, position,  Quaternion.identity);
        float angle = Vector3.Angle(targetDir, new Vector3(1.0f, 0.0f, 0.0f));
        laser.transform.Rotate(0.0f, 0.0f, angle, Space.World);

        //do this rotate in an coroutined animation(TODO)
        //laser.transform.rotate(0.0f, 0.0f, degree);
    }

    void lasterAttack2(int stage, Vector3 playerPos) {//horizontal/perpenticular
        //initialize a laser prefab
        if (stage == 1) {

        } else if (stage == 2) {

        } else if (stage == 3) {

        }
    }

    void singleLasterAttack(bool horizontal, Vector3 center, Vector3 trans) {
        //initialize single laser in the center
        GameObject laser = Instantiate(laserPrefab, center, Quaternion.identity);

        if (!horizontal) {
            //rotate by 90 degrees then scale it
            laser.transform.Rotate(0.0f, 0.0f, 90.0f, Space.World);
            laser.transform.localScale +=  new Vector3(0.0f, 4.0f, 0.0f);
        } else {
            //scale it
            laser.transform.localScale +=  new Vector3(7.0f, 0.0f, 0.0f);
        }

        //laser position
        laser.transform.position += trans;
    }

    void missileAttack(int stage) {
        //initialize a missile prefab thats gonna operate on its own term(with a rigidbody)

    }

    void bezierMissileAttack(int stage) {
        //initialize a bezier curve missile 

    }

    void upswept() {
        //

    }

    void dash() {

    }
}
