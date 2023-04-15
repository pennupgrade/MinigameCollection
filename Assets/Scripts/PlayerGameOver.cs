using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGameOver : MonoBehaviour
{
    public GameManagerScript gameManager;
    private bool gameIsOver = false;
    //Collision with enemy
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Enemy" && !gameIsOver)
        {
            gameIsOver = true;
            gameManager.gameOver();
        }
    }
}
