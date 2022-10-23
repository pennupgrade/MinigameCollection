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
    void Awake() {
        sweepStyle = false;
    }
    void Start()
    {
        //Angle = 0f;
        //if (!destroyTime) destroyTime = 1f;
        //rotatePos = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //print("rotateWorking");
        if (sweepStyle) {
            transform.RotateAround(rotatePos, new Vector3(0, 0, 1), (Angle / destroyTime) * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerScript>().AddDamage(Damage);
        }
    }
}
