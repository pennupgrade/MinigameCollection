using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public float Damage;
    public float Angle;
    public Vector3 rotatePos;
    public float destroyTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(rotatePos, new Vector3(0, 0, 1), (Angle / destroyTime) * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerScript>().AddDamage(Damage);
        }
    }
}
