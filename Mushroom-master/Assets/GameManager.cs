using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    private bool gameHasEnded = false;

    public GameObject GameOverPanel;
    public GameObject GameWonPanel;

    IEnumerator waitEndScreen(float time)
    {
        yield return new WaitForSeconds(time);

        GameOverPanel.SetActive(true);
    }

    public void EndGame()
    {
        if(!gameHasEnded)
        {
            gameHasEnded = true;
            Debug.Log("Game Over!");
            StartCoroutine(waitEndScreen(4f));

        }
    }
    public void CompleteGame()
    {
        if(!gameHasEnded)
        {
            gameHasEnded = true;
            Debug.Log("Game won!");
            StartCoroutine(waitEndScreen(4f));
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
 