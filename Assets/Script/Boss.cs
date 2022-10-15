using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private int stage;
    public float hp;
    private float DistanceToPlayer;
    public GameObject player;
    //so for this Boss the scripted behavior will be 
    // Start is called before the first frame update
    public enum BossActionType {
        Idle,
        LaserAttack1,
        LaserAttack2,
        MissileAttack,
        BezierMissileAttack,
        UpSwept,
        Dash,
        Dead
    }

    void Start()
    {
        stage = 0;
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        checkStageChange();
        switch (stage) {
            case 0:

            break;

            case 1:

            break;

            case 2:

            break;

            case 3:

            break;
        }
    }

    void stageTransition(int stage) {
        if (stage == 1) {
            //play stage change animation for the second stage
        } else if (stage == 2) {
            //play stage change animation for the third stage
        } else {
            //play dead animation for the forth stage and close all possible patterns
        }
    }

    public void doDamage(float num) {
        if (hp >= num) {
            hp -= num;
        } else {
            hp = 0.0f;
        }
    }

    void checkStageChange() {
        if (hp <= 70.0f && stage == 0) {
            stage++;
            stageTransition(1);
        } else if (hp <= 30.0f && stage == 1) {
            stage++;
            stageTransition(2);
        } else if (hp <= 0.0f && stage == 2) {
            stage++;
            stageTransition(3);
        }
    }
}
