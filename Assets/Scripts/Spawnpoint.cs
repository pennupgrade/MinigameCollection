using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnpoint : MonoBehaviour
{
    public GameObject enemy;

    private int timer = 0;
    private int spawnInterval = 1080;

    void Update()
    {
        if (timer % spawnInterval == 0) {
            Spawn();
        }

        timer++;
    }

    void Spawn() {
        Instantiate(enemy, transform.position, Quaternion.identity);
    }
}
