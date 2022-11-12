using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform[] spawnPoints;
    public GameObject enemy;
    public float spawnTimer = 0f;
    public float gameTimer = 0f;
    public float spawnTime = 5f;
    public static int enemiesAlive = 0;
    public int maxEnemies = 8;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // update timers
        spawnTimer += Time.deltaTime;
        gameTimer += Time.deltaTime;

        // if spawntime is reached, increase time
        if (spawnTimer >= spawnTime && enemiesAlive < maxEnemies){
            int randPoint = Random.Range(0, spawnPoints.Length);
            Instantiate(enemy, spawnPoints[randPoint].position, transform.rotation);
            spawnTimer = 0f;
            enemiesAlive++;
        }

        if (gameTimer % 15 == 0) {
            spawnTime -= 0.1f;
        }
        
    }
}
