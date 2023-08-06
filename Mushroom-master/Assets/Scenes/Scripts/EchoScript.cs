using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoScript : MonoBehaviour
{
    private float timeBtwSpawns;
    public float startTimeBtwSpawns;
    private float timer = 0;

    public GameObject echo;
    private PlayerScript player; 

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerScript>();
        timeBtwSpawns = startTimeBtwSpawns;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.getIsDashing())
        {
            if (timeBtwSpawns <= 0)
            {
                GameObject instance = Instantiate(echo, transform.position, Quaternion.identity);
                Destroy(instance, 0.2f);
                timeBtwSpawns = startTimeBtwSpawns;
            }
            else
            {
                timeBtwSpawns -= Time.deltaTime;
            }
            timer += Time.deltaTime;
        }
        timer = 0;
    }
}
