using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{

    [SerializeField]
    private List<GameObject> possibleEnemies;

    private List<Transform> path;

    // PLACEHOLDER JUST GOING TO SPAWN EVERY X SECONDS
    private float nextSpawnTime = 0.0f;
    public float spawnRate = 5f; // # of seconds b/n spawns

    void SpawnEnemy(int index)
    {
        GameObject newEnemy = Instantiate(possibleEnemies[index], path[0].position, Quaternion.identity);
        newEnemy.GetComponent<Enemy>().Waypoints = path;
    }

    // Start is called before the first frame update
    void Start()
    {
        path = new List<Transform>();
        for (int i = 0; i < transform.childCount; i++)
        {
            path.Add(transform.GetChild(i));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            nextSpawnTime += spawnRate;
            SpawnEnemy(0);
        }
    }
}
