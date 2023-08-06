using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour
{
    public GameManager gameManager;
    
    public void RestartGame()
    {
        Debug.Log("Restart Button Clicked");
        gameManager.Restart();
    }
}
