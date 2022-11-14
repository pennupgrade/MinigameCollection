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
    List<int> levelThresholds;
    List<float> levelSpawnrates;
    
    List<List<float>> enemyProbabilities = new List<List<float>>();
    
    
    void SpawnEnemy(int index)
    {
        GameObject newEnemy = Instantiate(possibleEnemies[index], path[0].position, Quaternion.identity);
        newEnemy.GetComponent<Enemy>().Waypoints = path;
    }

    // Start is called before the first frame update
    void Start()
    {

        // level definitions

        // amount required to go to next level (last one doesn't matter, will never be accessed anyway)
        levelThresholds = new List<int>()   {10,20,30,40,50,75,100,999};

        // spawn rates at each level
        levelSpawnrates = new List<float>() {5f,3f,2f,1f,0.5f,0.25f,0.25f,0.25f};

        // probability distributions at each level
        // normal, slow, fast, big, kill you
        enemyProbabilities.Add(new List<float>(){1f,0f,0f,0f,0f});
        enemyProbabilities.Add(new List<float>(){0.8f,0.1f,0.1f,0f,0f});
        enemyProbabilities.Add(new List<float>(){0.5f,0.25f,0.25f,0f,0f});
        enemyProbabilities.Add(new List<float>(){0.45f,0.22f,0.23f,0.01f,0f});
        enemyProbabilities.Add(new List<float>(){0.35f,0.3f,0.3f,0.05f,0f});
        enemyProbabilities.Add(new List<float>(){0f,0.45f,0.45f,0.1f,0f});
        enemyProbabilities.Add(new List<float>(){0f,0f,0f,1f,0f});
        enemyProbabilities.Add(new List<float>(){0f,0f,0f,0f,1f}); // hopefully they just die here

        nextSpawnTime = Time.time + 3;
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
            nextSpawnTime += levelSpawnrates[level];
            float rand = Random.Range(0.0f,1.0f);
            float p = 0;
            bool spawned = false;
            for (int i = 0; i < possibleEnemies.Count; i++)
            {
                p += enemyProbabilities[level][i];
                if (p > rand)
                {
                    SpawnEnemy(i);
                    spawned = true;
                    break;
                }
            }
            if (!spawned)
            {
                SpawnEnemy(0);
                Debug.Log("Something weird happened. Spawning default enemy. Check enemyProbabilities list.");
            }
            
        }

        if (level < levelThresholds.Count - 1&& GameManager.Instance.Killed >= levelThresholds[level])
        {
            spawnRate = levelSpawnrates[level];
            level += 1;
        }
    }
}
