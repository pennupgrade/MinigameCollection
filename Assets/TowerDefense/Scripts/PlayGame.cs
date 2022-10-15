using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{

    public void clickPlay() {
        SceneManager.LoadScene("TestScene");
    }
}
