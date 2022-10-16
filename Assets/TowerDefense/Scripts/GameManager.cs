using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private static GameManager instance;
    public static GameManager Instance => GameManager.instance;

    private Shakeable cameraShake;

    [SerializeField]
    private int health;

    public int Health
    {
        get { return health; }
        set { SetHealth(value);  }
    }

    public int Money
    {
        get { return money; }
        set { SetMoney(value); }
    }

    [SerializeField]
    private int money;

    public Text healthText;
    public Text moneyText;


    public void Die()
    {
        // placeholder just quit the editor
        //UnityEditor.EditorApplication.isPlaying = false;
        SceneManager.LoadScene("EndUI");
    }

    public void SetHealth(int h)
    {

        // if you lose health, shake the camera
        if (h < health)
        {
            ShakeCamera();
        }

        health = h;
        healthText.text = h.ToString();

        if (health <= 0)
        {
            Die();
        }

    }

    public void SetMoney(int h)
    {
        money = h;
        moneyText.text = h.ToString();
    }

    public void ShakeCamera()
    {
        cameraShake.BeginShake();
    }

    
    private void Awake()
    {
        if (GameManager.instance != null && GameManager.instance != this)
        {
            throw new System.Exception("An instance of this singleton already exists.");
        }
        else
        {
            GameManager.instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        healthText.text = health.ToString();
        moneyText.text = money.ToString();
        cameraShake = Camera.main.GetComponent<Shakeable>();
    }  

    // Update is called once per frame
    void Update()
    {
        
    }
}
