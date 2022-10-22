using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public GameObject laserPrefab;
    public GameObject missilePrefab;

    private Vector3 positionAtLeft;
    private Vector3 positionAtRight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void laserAttack1(int stage, Vector3 startPos, Vector3 playerPos, float time) {//sweep style
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
        float distance = Vector3.Distance(startPos, playerPos);
        Vector3 targetDir = playerAtRight ? playerPos - startPos : startPos - playerPos;
        Vector3 position = playerAtRight ? (playerPos - startPos)/2 + startPos:  (startPos - playerPos)/2 + playerPos;
        GameObject laser = Instantiate(laserPrefab, position, Quaternion.identity);
        float angle = Vector3.Angle(targetDir, new Vector3(1.0f, 0.0f, 0.0f));
        laser.transform.Rotate(0.0f, 0.0f, angle, Space.World);
        laser.transform.localScale += new Vector3(distance - 1, 0f, 0f);
        Laser laserScript = laser.GetComponent<Laser>();
        laserScript.rotatePos = this.transform.position;
        laserScript.sweepStyle = true;
        laserScript.Angle = degree;
        laserScript.destroyTime = time;
        Destroy(laser, time);
        /*laser.Angle = Vector3.Angle(targetDir, new Vector3(1.0f, 0.0f, 0.0f));
        laser.transform.Rotate(0.0f, 0.0f, angle, Space.World);*///this rotation should be done in laser.cs with update()
    }

    public void laserAttack2(int stage, Vector3 playerPos, float time) {//horizontal/perpenticular
        //initialize a laser prefab
        //1,2,3 for now
        Vector3 center = new Vector3(0.0f, 0.0f, 0.0f);
        var trans1 = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0f);
        if (stage == 1) {
            singleLaserAttack(true, center, playerPos + trans1, time);
        } else if (stage == 2) {
            singleLaserAttack(true, center, playerPos + trans1, time);
            trans1 = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0f);
            singleLaserAttack(false, center, playerPos + trans1, time);
        } else if (stage == 3) {
            singleLaserAttack(true, center, playerPos + trans1, time);
            trans1 = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0f);
            singleLaserAttack(false, center, playerPos + trans1, time);
            trans1 = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0f);
            singleLaserAttack(true, center, playerPos + trans1, time);
            trans1 = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0f);
            singleLaserAttack(false, center, playerPos + trans1, time);
        }
    }

    void singleLaserAttack(bool horizontal, Vector3 center, Vector3 trans, float time) {
        //initialize single laser in the center
        GameObject laser = Instantiate(laserPrefab, center, Quaternion.identity);
        Destroy(laser, time);

        if (!horizontal) {
            //rotate by 90 degrees then scale it
            laser.transform.Rotate(0.0f, 0.0f, 90.0f, Space.World);
            laser.transform.localScale +=  new Vector3(0.0f, 10.0f, 0.0f);
        } else {
            //scale it
            laser.transform.localScale +=  new Vector3(18.0f, 0.0f, 0.0f);
        }

        //laser position
        laser.transform.position += trans;
    }

    public void missileAttack(int stage, float time) {
        //initialize a laser prefab
        if (stage == 1)
        {

        }
        else if (stage == 2)
        {

        }
        else if (stage == 3)
        {

        }
    }

    void singleMissileAttack(Vector3 center)
    {
        //initialize a missile prefab thats gonna operate on its own term(with a rigidbody)
        GameObject missile = Instantiate(missilePrefab, this.transform.position, Quaternion.identity);
    }

    void bezierMissileAttack(int stage) {
        //initialize a bezier curve missile 

    }

    void upswept() {
        //do animation of upswept

        //like laser attack we generate collider to see if sword collider with player


    }

    void dash() {

    }
}
