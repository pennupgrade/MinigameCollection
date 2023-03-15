using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnpoint : MonoBehaviour
{
    public GameObject enemy;

    int timer = 0;
    int spawnInterval = 1080;
    int numToSpawn = 0;

    bool isSpawning = false;

    void Update()
    {
        if (isSpawning && numToSpawn > 0) {
            if (timer % spawnInterval == 0) {
                numToSpawn--;
                Spawn();
            }
            timer++;
        }
    }

    public void Begin(int n) {
        numToSpawn = n;
        timer = 0;
        isSpawning = true;
    }

    void Spawn() {
        Instantiate(enemy, transform.position, Quaternion.identity);
    }
}