using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform[] spawnPoints;
    public GameObject enemy;

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetMouseButtonDown(0)){
            int randPoint = Random.Range(0, spawnPoints.Length);
            Instantiate(enemy, spawnPoints[randPoint].position, transform.rotation);
        }
        
    }
}
