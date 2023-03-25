using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private float spawnInterval = 3.5f;

    public Transform trackingTarget;

    public float smoothSpeed = 0.125f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(spawnInterval, enemyPrefab));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        float upOrDown = Random.Range(0f, 1f);
        float leftOrRight = Random.Range(0f, 1f);

        if (upOrDown < 0.5f && leftOrRight < 0.5f) 
        {
            GameObject newEnemy = Instantiate(enemy, new Vector3(transform.position.x + Random.Range(-10f, -5f), transform.position.y + Random.Range(-10f, -5f), 0), Quaternion.identity);
        }

        if (upOrDown < 0.5f && leftOrRight >= 0.5f) 
        {
            GameObject newEnemy = Instantiate(enemy, new Vector3(transform.position.x + Random.Range(-10f, -5f), transform.position.y + Random.Range(5f, 10f), 0), Quaternion.identity);
        }

        if (upOrDown >= 0.5f && leftOrRight < 0.5f) 
        {
            GameObject newEnemy = Instantiate(enemy, new Vector3(transform.position.x + Random.Range(5f, 10f), transform.position.y + Random.Range(-10f, -5f), 0), Quaternion.identity);
        }

        if (upOrDown >= 0.5f && leftOrRight >= 0.5f) 
        {
            GameObject newEnemy = Instantiate(enemy, new Vector3(transform.position.x + Random.Range(5f, 10f), transform.position.y + Random.Range(5f, 10f), 0), Quaternion.identity);
        }
        StartCoroutine(spawnEnemy(interval, enemy));
    }

    void Update()
    {
        transform.position = new Vector3(trackingTarget.position.x, trackingTarget.position.y, transform.position.z);

    }
}
