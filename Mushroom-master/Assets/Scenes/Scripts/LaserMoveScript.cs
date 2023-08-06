using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMoveScript : MonoBehaviour
{
    private float time = 0;
    private float timer = 1.0f;
    private bool dir = true;
    private float rotateSpeed = 30;

    public void changeDir()
    {
        dir = !dir;
    }

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 6);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
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
    }
}
