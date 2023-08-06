using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    private float health = 500;
    private float timer;
    private float angle = 0;
    private bool dir = true;
    private int moveCount = 3;

    public PlayerScript player;

    public LaserMoveScript laser;
    public TrickLaserScript trickLaser;
    public GameObject staticLaser;
    public GameObject trickStaticLaser;
    public Animator animator;
    private bool isAlive = true;
    private int phase = 0;

    public bool getIsEnraged()
    {
        return (phase == 1);
    }

    IEnumerator waitColor(float time)
    {
        yield return new WaitForSeconds(time);

        this.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
    }

    public void getHit(float damage)
    {
        health -= damage;
        this.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1, 0.5f, 1);
        StartCoroutine(waitColor(0.2f));
    }

    // Start is called before the first frame update
    void Start()
    {
        move();
        timer = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
            if (health <= 0)
            {
                animator.SetBool("dead", true);
                isAlive = false;
            }
            if (health <= 300 && phase == 0)
            {
                phase = 1;
                animator.SetBool("enraged", true);
                timer = 2f;
            }
            if (moveCount <= 0)
            {
                Debug.Log("Move");
                move();
                moveCount = Random.Range(2, 5);
                timer = 3f;
            }
            else
            {
                if (isAlive)
                {
                    int random = Random.Range(0, 5);
                    if (random == 0)
                    {
                        Debug.Log("Laser");
                        if (getIsEnraged())
                        {
                            int random2 = Random.Range(0, 3);
                            if (random2 == 0)
                            {
                                trickLaserAttack();
                            }
                            else
                            {
                                laserAttack();
                            }
                        }
                        else
                        {
                            laserAttack();
                        }
                        timer = 7;
                    }
                    else if (random == 1)
                    {
                        Debug.Log("Spiral");
                        spiralBubbleAttack();
                        timer = 7;
                    }
                    else if (random == 2)
                    {
                        Debug.Log("Layer");
                        layerBubbleAttack();
                        timer = 7;
                    }
                    else if (random == 3)
                    {
                        Debug.Log("Combo");
                        bubbleCombo();
                        timer = 13;
                    }
                    else if (random == 4)
                    {
                        Debug.Log("Radiance");
                        if (getIsEnraged())
                        {
                            int random2 = Random.Range(0, 2);
                            if (random2 == 0)
                            {
                                trickTripleRadianceLaser();
                            }
                            else
                            {
                                tripleRadianceLaser();
                            }
                        }
                        else
                        {
                            tripleRadianceLaser();
                        }
                        timer = 3f;
                    }
                    moveCount--;
                }
            }
        }
        timer -= Time.deltaTime;
        if (!isAlive) {
            FindObjectOfType<GameManager>().CompleteGame();
        }
    }

    IEnumerator waitMove(float time, Vector3 newPos)
    {
        yield return new WaitForSeconds(time);

        transform.position = newPos;
        animator.SetInteger("state", 2);
    }

    IEnumerator waitDisableHitbox(float time)
    {
        yield return new WaitForSeconds(time);

        this.transform.GetChild(0).GetComponent<CircleCollider2D>().enabled = false;
    }

    IEnumerator waitEnableHitbox(float time)
    {
        yield return new WaitForSeconds(time);

        this.transform.GetChild(0).GetComponent<CircleCollider2D>().enabled = true;
    }

    IEnumerator waitTransitionState(float time)
    {
        yield return new WaitForSeconds(time);

        animator.SetInteger("state", 0);
    }

    void move()
    {
        animator.SetInteger("state", 1);
        int random = Random.Range(0, 5);

        Vector3 newPos;
        if (random == 0)
        {
            newPos = new Vector3(-4.2f, 0.5f, 0);
        } else if (random == 1)
        {
            newPos = new Vector3(-10.5f, 4.45f, 0);
        } else if (random == 2)
        {
            newPos = new Vector3(3.3f, 4.45f, 0);
        } else if (random == 3)
        {
            newPos = new Vector3(2f, -4f, 0);
        } else
        {
            newPos = new Vector3(-10.1f, -1.45f, 0);
        }
        StartCoroutine(waitDisableHitbox(0.4f));
        StartCoroutine(waitMove(0.81f, newPos));
        StartCoroutine(waitEnableHitbox(1.1f));
        StartCoroutine(waitTransitionState(1.5f));
    }

    void laserAttack()
    {
        randomizeDir();
        LaserMoveScript laserInstance = Instantiate(laser, this.gameObject.transform);
        if (dir)
        {
            laserInstance.changeDir();
        }
        int startAngle = Random.Range(0, 360);
        laserInstance.transform.Rotate(0, 0, startAngle);
        for (int i = 0; i < 7; i++)
        {
            LaserMoveScript nextLaserInstance = Instantiate(laser, this.gameObject.transform);
            nextLaserInstance.transform.Rotate(0, 0, startAngle + 45 * (i + 1));
            if (dir)
            {
                nextLaserInstance.changeDir();
            }
        }
    }

    void trickLaserAttack()
    {
        randomizeDir();
        TrickLaserScript laserInstance = Instantiate(trickLaser, this.gameObject.transform);
        if (dir)
        {
            laserInstance.changeDir();
        }
        int startAngle = Random.Range(0, 360);
        laserInstance.transform.Rotate(0, 0, startAngle);
        for (int i = 0; i < 7; i++)
        {
            TrickLaserScript nextLaserInstance = Instantiate(trickLaser, this.gameObject.transform);
            nextLaserInstance.transform.Rotate(0, 0, startAngle + 45 * (i + 1));
            if (dir)
            {
                nextLaserInstance.changeDir();
            }
        }
    }

    IEnumerator delayRadianceLaser(float time)
    {
        yield return new WaitForSeconds(time);

        radianceLaser();
    }

    void tripleRadianceLaser()
    {
        radianceLaser();
        StartCoroutine(delayRadianceLaser(1f));
        StartCoroutine(delayRadianceLaser(2f));
    }

    void radianceLaser()
    {
        GameObject laserInstance = Instantiate(staticLaser, this.gameObject.transform);
        int startAngle = Random.Range(0, 360);
        laserInstance.transform.Rotate(0, 0, startAngle);
        for (int i = 0; i < 7; i++)
        {
            GameObject nextLaserInstance = Instantiate(staticLaser, this.gameObject.transform);
            nextLaserInstance.transform.Rotate(0, 0, startAngle + 45 * (i + 1));
        }
    }

    IEnumerator trickDelayRadianceLaser(float time)
    {
        yield return new WaitForSeconds(time);

        trickRadianceLaser();
    }

    void trickTripleRadianceLaser()
    {
        trickRadianceLaser();
        int random = Random.Range(0, 2);
        if (random == 0)
        {
            StartCoroutine(delayRadianceLaser(1f));
        }
        else
        {
            StartCoroutine(trickDelayRadianceLaser(1f));
        }
        int random2 = Random.Range(0, 2);
        if (random == 0)
        {
            StartCoroutine(delayRadianceLaser(2f));
        }
        else
        {
            StartCoroutine(trickDelayRadianceLaser(2f));
        }
    }

    void trickRadianceLaser()
    {
        GameObject laserInstance = Instantiate(trickStaticLaser, this.gameObject.transform);
        int startAngle = Random.Range(0, 360);
        laserInstance.transform.Rotate(0, 0, startAngle);
        for (int i = 0; i < 7; i++)
        {
            GameObject nextLaserInstance = Instantiate(trickStaticLaser, this.gameObject.transform);
            nextLaserInstance.transform.Rotate(0, 0, startAngle + 45 * (i + 1));
        }
    }

    IEnumerator cancelInvoke(float time)
    {
        yield return new WaitForSeconds(time);

        CancelInvoke();
    }

    void spiralBubbleAttack()
    {
        randomizeDir();
        angle = 0;
        InvokeRepeating("spiralBubble", 0, 0.15f);
        StartCoroutine(cancelInvoke(6.9f));
    }

    void spiralBubble()
    {
        for (int i = 0; i <= 3; i++)
        {
            float bulDirX = transform.position.x + Mathf.Sin(((angle + 90f * i) * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos(((angle + 90f * i) * Mathf.PI) / 180f);
            Vector3 bulMoveVec = new Vector3(bulDirX, bulDirY, 0);
            Vector3 bulDir = (bulMoveVec - transform.position).normalized;

            GameObject bubbleInstance = BubblePool.bubblePoolInstance.getBubble();
            if (bubbleInstance != null)
            {
                bubbleInstance.transform.position = transform.position;
                bubbleInstance.transform.rotation = transform.rotation;
                bubbleInstance.SetActive(true);
                if (bubbleInstance.GetComponent<BubbleAttackScript>() != null)
                {
                    bubbleInstance.GetComponent<BubbleAttackScript>().setDir(bulDir);
                }
                if (bubbleInstance.GetComponent<TrickBubbleAttack>() != null)
                {
                    bubbleInstance.GetComponent<TrickBubbleAttack>().setDir(bulDir);
                }
            }
        }
        if (dir)
        {
            angle -= 10f;
        } else
        {
            angle += 10f;
        }

        if (angle >= 360 || angle <= -360)
        {
            angle = 0;
        }
    }

    void layerBubbleAttack()
    {
        randomizeDir();
        angle = 0;
        InvokeRepeating("layerBubble", 0, 0.5f);
        StartCoroutine(cancelInvoke(6.9f));
    }

    void layerBubble()
    {
        if (angle == 0)
        {
            angle = 10;
        } else if (angle == 10)
        {
            angle = 0;
        }
        for (int i = 0; i <= 17; i++)
        {
            float bulDirX = transform.position.x + Mathf.Sin(((angle + 20f * i) * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos(((angle + 20f * i) * Mathf.PI) / 180f);
            Vector3 bulMoveVec = new Vector3(bulDirX, bulDirY, 0);
            Vector3 bulDir = (bulMoveVec - transform.position).normalized;

            GameObject bubbleInstance = BubblePool.bubblePoolInstance.getBubble();
            if (bubbleInstance != null)
            {
                bubbleInstance.transform.position = transform.position;
                bubbleInstance.transform.rotation = transform.rotation;
                bubbleInstance.SetActive(true);
                if (bubbleInstance.GetComponent<BubbleAttackScript>() != null)
                {
                    bubbleInstance.GetComponent<BubbleAttackScript>().setDir(bulDir);
                }
                if (bubbleInstance.GetComponent<TrickBubbleAttack>() != null)
                {
                    bubbleInstance.GetComponent<TrickBubbleAttack>().setDir(bulDir);
                }
            }
        }
    }

    IEnumerator comboSpiral1(float time)
    { 
        yield return new WaitForSeconds(time);

        layerBubbleAttack();
    }

    IEnumerator comboSpiral2(float time)
    {
        yield return new WaitForSeconds(time);

        spiralBubbleAttack();
    }

    void bubbleCombo()
    {
        randomizeDir();
        if (dir)
        {
            spiralBubbleAttack();
            StartCoroutine(comboSpiral1(4));
        } else
        {
            layerBubbleAttack();
            StartCoroutine(comboSpiral2(4));
        }
    }

    void randomizeDir()
    {
        int random = Random.Range(0, 10);
        if (random <= 5)
        {
            dir = false;
        } else
        {
            dir = true;
        }
    }
}
