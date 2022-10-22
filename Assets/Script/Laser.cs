using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float Damage;
    public float Angle;
    public Vector3 rotatePos;
    public float destroyTime;
    public bool sweepStyle;
    // Start is called before the first frame update
    void Start()
    {
        sweepStyle = false;
        Angle = 0f;
        destroyTime = 0f;
        rotatePos = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.RotateAround(rotatePos, new Vector3(0, 0, 1), (Angle / destroyTime) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerScript>().AddDamage(Damage);
        }
    }
}
