using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogVision : MonoBehaviour {
    Vector3 vis;
    private void Update() {
        if (transform.localScale.x > 0) {
            transform.localScale -= new Vector3((float)0.0005, (float)0.0005, (float)0.0005);
        }
    }
}