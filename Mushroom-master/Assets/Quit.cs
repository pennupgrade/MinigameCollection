using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManager gameManager;

    public void QuitGame()
    {
        Debug.Log("Quit Button Clicked");
        gameManager.Quit();
    }
}
