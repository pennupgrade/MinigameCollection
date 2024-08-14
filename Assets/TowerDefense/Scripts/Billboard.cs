using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// stolen from https://stackoverflow.com/questions/71626887/how-do-get-a-2d-sprite-to-face-the-camera-in-a-3d-unity-game
// Makes a 2d sprite always face the 3d camera
public class Billboard : MonoBehaviour
{
    private Transform cam;
    private void Start()
    {
        cam = Camera.main.transform;
    }
    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}
