using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private static GameManager instance;
    public static GameManager Instance => GameManager.instance;

    public Vector3 initialCameraPos;
    private Vector3 targetCameraPos;

    public bool timeSlowed = false;

    private Shakeable cameraShake;

    [SerializeField]
    private int health;

    private int enemiesKilled = 0;

    public int Killed
    {
        get { return enemiesKilled; }
        set { SetKilled(value);  }
    }

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
    public Text killedText;
    public GameObject towerUpgradePanel;


    public void Die()
    {
        // placeholder just quit the editor
        //UnityEditor.EditorApplication.isPlaying = false;
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject go in gos)
            Destroy(go);
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

    public void OpenTowerUpgradePanel(GameObject tower)
    {
        towerUpgradePanel.SetActive(true);
        towerUpgradePanel.GetComponent<TowerUpgrade>().Open(tower.GetComponent<Tower>());
        targetCameraPos = tower.transform.position + new Vector3(2,5,-5);
    }

    public void ReturnCameraToInitialPosition()
    {
        targetCameraPos = initialCameraPos;
    }

    public void SetMoney(int h)
    {
        money = h;
        moneyText.text = h.ToString();
    }

    public void SetKilled(int h)
    {
        enemiesKilled = h;
        killedText.text = h.ToString();
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
        initialCameraPos = new Vector3(0,12,-10);
        Camera.main.enabled = true;
        //initialCameraPos = Camera.main.transform.position;
        targetCameraPos = initialCameraPos;

    }  

    // Update is called once per frame
    void Update()
    {
        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, targetCameraPos, 0.03f); 
    }
}
