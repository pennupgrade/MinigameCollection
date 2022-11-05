using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSceneMove : MonoBehaviour
{
    private Rigidbody2D player;
    private Vector3 respawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        //player = GetComponent<Rigidbody2D>();
        respawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "NextLevel")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            // Or you can use SceneManager.LoadScene(1); to load a specific scene instead

            respawnPoint = transform.position;
        }
        else if (collision.tag == "PrevLevel")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            respawnPoint = transform.position;
        }
    }
}
