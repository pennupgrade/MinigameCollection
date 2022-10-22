using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverBack : MonoBehaviour
{
    public GameObject UiObject;
    // Start is called before the first frame update
    void Start()
    {
        UiObject.SetActive(false);
        
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        UiObject.SetActive(true);
        Debug.Log("Test");
    }

    void OnTriggerExit2D(Collider2D other)
    {
        UiObject.SetActive(true);
    }
}
