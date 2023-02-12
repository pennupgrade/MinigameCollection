using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    public Transform trackingTarget;

    public float smoothSpeed = 0.125f;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = new Vector3(trackingTarget.position.x, trackingTarget.position.y, transform.position.z);

    }
}
