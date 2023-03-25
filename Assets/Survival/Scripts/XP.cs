using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XP : MonoBehaviour
{

    float xp = 5; //will have to change later

    void Start()
    {
        
    }

    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Player")) {
            collision.gameObject.GetComponent<Player>().increaseXP(xp);
            Destroy(this.gameObject);
        }
    }
}
