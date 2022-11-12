using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public GameObject laserPrefab;
    public GameObject missilePrefab;
    public GameObject swordPrefab;

    private Vector3 positionAtLeft;
    private Vector3 positionAtRight;

    //public float dashForce = 100000;
    //private float gravity = 25;
    // Start is called before the first frame update
    public Vector3[] pos = new Vector3[]{new Vector3(-6f, -0.98f, 0) , new Vector3(6, -0.98f, 0), new Vector3(0, -0.98f, 0)};
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
        Vector3 targetDir = playerPos - startPos;
        //targetDir.y = startPos.y;
        Vector3 position = startPos - distance*2*Vector3.Normalize(targetDir);
        position.y = startPos.y;
        GameObject laser = Instantiate(laserPrefab, position, Quaternion.identity);
        float angle = Vector3.Angle(targetDir, new Vector3(1.0f, 0.0f, 0.0f));
        //laser.transform.Rotate(0.0f, 0.0f, angle, Space.World);
        laser.transform.RotateAround(startPos, new Vector3(0, 0, 1), angle);
        laser.transform.localScale += new Vector3(distance*4 - 1, 0f, 0f);
        Laser laserScript = laser.GetComponent<Laser>();
        laserScript.rotatePos = this.transform.position;
        laserScript.sweepStyle = true;
        laserScript.Angle = playerPos.y > startPos.y  ? degree : -degree;
        if (playerAtRight) {
            laserScript.Angle = -laserScript.Angle;
        }
        laserScript.destroyTime = time;
        Destroy(laser, time);
        /*laser.Angle = Vector3.Angle(targetDir, new Vector3(1.0f, 0.0f, 0.0f));
        laser.transform.Rotate(0.0f, 0.0f, angle, Space.World);*/
        //this rotation should be done in laser.cs with update()
    }

    public void laserAttack2(int stage, Vector3 playerPos, float time) {//horizontal/perpenticular
        //initialize a laser prefab
        //1,2,3 for now
        Vector3 center = new Vector3(0.0f, 0.0f, 0.0f);
        
        if (stage == 1) {
            singleLaserAttack(true, center, playerPos, time);
        } else if (stage == 2) {
            singleLaserAttack(true, center, playerPos, time);
            singleLaserAttack(false, center, playerPos, time);
        } else if (stage == 3) {
            singleLaserAttack(true, center, playerPos, time);
            singleLaserAttack(false, center, playerPos, time);
            singleLaserAttack(true, center, playerPos, time);
            singleLaserAttack(false, center, playerPos, time);
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
        var trans1 = new Vector3(0, 0, 0);
        //do some randomization
        if (horizontal) {
            trans1.y += Random.Range(-1.0f, 1.0f);
        } else {
            trans1.x += Random.Range(-1.0f, 1.0f);
        }
        laser.transform.position = new Vector3(Mathf.Round(laser.transform.position.x + trans1.x),Mathf.Round(laser.transform.position.y + trans1.y),Mathf.Round(laser.transform.position.z + trans1.z) );

    }

    public void missileAttack(int stage, Vector3 playerPos, float time) {
        //initialize a missile prefab
        if (stage == 1)
        {
            //send one missile for now
            singleMissileAttack(playerPos, time);
        }
        else if (stage == 2)
        {
            singleMissileAttack(playerPos, time);
            //add more for stage change

        }
        else if (stage == 3)
        {
            singleMissileAttack(playerPos, time);
            //add more for stage change
        }
    }

    void singleMissileAttack(Vector3 center, float time)
    {
        //initialize a missile prefab thats gonna operate on its own term(with a rigidbody)
        Vector3 missileLauncher = this.transform.position;
        missileLauncher.y += 2;
        GameObject missile = Instantiate(missilePrefab, missileLauncher, Quaternion.identity);
        missile.GetComponent<Missile>().targetPos = center;
    }

    public void upswept(int stage, Vector3 startPos, Vector3 playerPos, float time) {
        //do animation of upswept

        //like laser attack we generate collider to see if sword collider with player
        float degree = -180;
        bool playerAtRight = false;
        if (playerPos.x > startPos.x)
        {
            degree = -degree;
            playerAtRight = true;
        }
        
        GameObject sword = Instantiate(swordPrefab, this.transform.position, Quaternion.identity);
        Vector3 trans1 = playerAtRight ? new Vector3(3, 0, 0) : new Vector3(-3, 0, 0);
        sword.transform.position += trans1;
        Sword swordScript = sword.GetComponent<Sword>();
        swordScript.Angle = degree;
        swordScript.rotatePos = this.transform.position;
        swordScript.destroyTime = time;
        Destroy(sword, time);
    }

    IEnumerator lerpPosition(Vector3 targetPos, float duration) {
        float time = 0;
        Vector3 startPosition = transform.position;
        targetPos.y = startPosition.y;
        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPos, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPos;
    }

    public void dash(int stage) {
        Vector3 targetPos = pos[stage-1];
        StartCoroutine(lerpPosition(targetPos, 1.5f));
    }
}
