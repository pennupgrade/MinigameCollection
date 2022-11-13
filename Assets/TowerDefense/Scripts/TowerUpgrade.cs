using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerUpgrade : MonoBehaviour
{
    
    Tower tower;
    
    public Text currentAttackSpeed;
    public Text attackSpeedUpgradeCost;
    public Text currentDamage;
    public Text damageUpgradeCost;

    // Start is called before the first frame update
    void Start()
    {
        Close();
    }

    public void UpgradeDamage() {
        if (GameManager.Instance.Money >= tower.damageCost)
        {
            tower.damage += 10;
            GameManager.Instance.Money -= tower.damageCost;
            tower.damageCost += 5;
            UpdateText();
        }
    }
    
    public void UpgradeSpeed() {
        if (GameManager.Instance.Money >= tower.speedCost)
        {
            tower.shootDelay /= 1.1f;
            GameManager.Instance.Money -= tower.speedCost;
            tower.speedCost += 5;
            UpdateText();
        }
    }

    void UpdateText()
    {
        currentDamage.text = "Current Damage Per Bullet: " + tower.damage;
        damageUpgradeCost.text = "Cost: " + tower.damageCost;
        
        attackSpeedUpgradeCost.text = "Cost: " + tower.speedCost;
        currentAttackSpeed.text = "Current Bullets Per Second: " + (1/tower.shootDelay).ToString("F2");
    }

    public void Open(Tower t)
    {
        //Time.timeScale = 0;
        tower = t;
        UpdateText();
    }

    public void Close()
    {
        gameObject.SetActive(false);
        //Time.timeScale = 1;
        GameManager.Instance.ReturnCameraToInitialPosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
