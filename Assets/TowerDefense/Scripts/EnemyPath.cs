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

    int level = 0;
    List<int> levelThresholds = new List<int>() {10,20,30,40,50,75};
    List<float> levelSpawnrates = new List<float>() {3f,2f,1f,0.5f,0.25f,0.1f};
    
    void SpawnEnemy(int index)
    {
        Debug.Log("Spawns Enemy");
        GameObject newEnemy = Instantiate(possibleEnemies[index], path[0].position, Quaternion.identity);
        newEnemy.GetComponent<Enemy>().Waypoints = path;
    }

    // Start is called before the first frame update
    void Start()
    {
        nextSpawnTime = Time.time;
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

        if (level <= levelThresholds.Count && GameManager.Instance.Killed >= levelThresholds[level])
        {
            spawnRate = levelSpawnrates[level];
            level += 1;
        }
    }
}
