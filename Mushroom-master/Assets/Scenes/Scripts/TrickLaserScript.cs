using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrickLaserScript : MonoBehaviour
{
    private float time = 0;
    private float timer = 1.0f;
    private float rotateTimer = 0.8f;
    private bool dir = true;
    private float rotateSpeed = 30;
    private bool rotated = false;

    public void changeDir()
    {
        dir = !dir;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.transform.GetChild(0).transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(0.47f, 0.2f, 1);
        Destroy(this.gameObject, 6);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rotateTimer <= 0)
        {
            if (!rotated)
            {
                this.transform.Rotate(0, 0, 22.5f);
                rotated = true;
            }
        }
        if (timer <= 0)
        {
            if (dir)
            {
                this.transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
            }
            else
            {
                this.transform.Rotate(0, 0, -rotateSpeed * Time.deltaTime);
            }
            time += Time.deltaTime;
        }
        timer -= Time.deltaTime;
        rotateTimer -= Time.deltaTime;
    }
}
