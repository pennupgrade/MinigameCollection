using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int stage;
    public float hp;
    public float DistanceToPlayer;
    public GameObject player;
    private BossAttack bossAtk;
    //so for this Boss the scripted behavior will be 
    // Start is called before the first frame update
    public enum BossActionType {
        Idle,
        LaserAttack1,
        LaserAttack2,
        MissileAttack,
        UpSwept,
        Dash,
        Dead
    }

    public Dictionary<BossActionType, float> BossActionTime = new Dictionary<BossActionType, float>()
    {
        { BossActionType.Idle, 2.0f},
        { BossActionType.LaserAttack1, 2.5f},
        {BossActionType.LaserAttack2, 2.5f },
        {BossActionType.MissileAttack, 2.5f },
        {BossActionType.UpSwept, 2.5f },
        {BossActionType.Dash, 2.5f }
    };

    //private string[] BossActionStage1 = new string[]{ "LaserAttack1", "LaserAttack2", "LaserAttack1", "Dash" , "UpSwept" };
    //private string[] BossActionStage1 = new string[] { "UpSwept", "UpSwept" };
    private string[] BossActionStage1 = new string[] { "MissileAttack" , "MissileAttack" };


    IEnumerator processAttack(int iter, string[] stage, int totalIter)
    {
        //retrieve and process the enum value
        print("processAttack" + iter + " " + totalIter);
        BossActionType currentActionType = (BossActionType)System.Enum.Parse(typeof(BossActionType), stage[iter]);
        float waitTime = ProcessBossAction(currentActionType);



        yield return new WaitForSeconds(waitTime);
        if (iter + 1 < totalIter)
        {
            yield return processAttack(iter + 1, stage, totalIter);
        }
        else
        {
            yield return null;
        }
    }

    float ProcessBossAction(BossActionType currentAction)
    {
        if (bossAtk == null)//just in case
        {
            print("BossAtk is null cannot proceed");
        } 
        switch (currentAction)
        {
            case BossActionType.Idle:
                //do idle animation? todo
                break;
            case BossActionType.LaserAttack1:
                //process one laser attack
                bossAtk.laserAttack1(stage, this.gameObject.transform.position, player.transform.position, BossActionTime[currentAction]);
                break;
            case BossActionType.LaserAttack2:
                bossAtk.laserAttack2(stage, player.transform.position, BossActionTime[currentAction]);
                break;
            case BossActionType.MissileAttack:
                bossAtk.missileAttack(stage, player.transform.position, BossActionTime[currentAction]);
                break;
            case BossActionType.Dash:
                bossAtk.dash(stage);
                break;
            case BossActionType.UpSwept:
                bossAtk.upswept(stage, this.gameObject.transform.position, player.transform.position, BossActionTime[currentAction]);
                break;
        }
        return BossActionTime[currentAction];
    }

    void Start()
    {
        stage = 1;
        player = GameObject.FindWithTag("Player");
        bossAtk = gameObject.GetComponent<BossAttack>();
        IEnumerator atk = processAttack(0, BossActionStage1, BossActionStage1.Length);
        StartCoroutine(atk);
    }

    // Update is called once per frame
    void Update()
    {
        DistanceToPlayer = Vector3.Distance(this.transform.position, player.transform.position);
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
