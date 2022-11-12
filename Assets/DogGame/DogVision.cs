using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogVision : MonoBehaviour {
    Vector3 vis;
    float time = 0;
    bool low_energy = false;
    private void Update() {
        // low energy; breathing vision radius
        if (low_energy) {
            time += 0.01f % 3.14f; // Random.Range(0.01f, 0.1f);
            float wave = 0.005f * Mathf.Sin(time);
            transform.localScale += new Vector3(wave, wave, wave);
        }

        if (transform.localScale.x > 2 && !low_energy) {
            transform.localScale -= new Vector3((float)0.0005, (float)0.0005, (float)0.0005);
        }
        // resets low_energy if food buff was gained
        low_energy = transform.localScale.x < 3;
    }


}