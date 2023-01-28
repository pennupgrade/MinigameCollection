using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour 
{
    private float curHealth = 1.0f;
    private float invincibilityTimer = 0.0f;

    public HealthBar healthBar;
    public GameObject gameOverText;

    void Start() 
    {
        gameOverText.SetActive(false);
    }

    void Update() 
    {
        if (invincibilityTimer > 0) {
            invincibilityTimer = Mathf.Max(0.0f, invincibilityTimer - Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && invincibilityTimer == 0)
        {
            Debug.Log("enemy hit on player");
            takeDamage(0.1f);
            invincibilityTimer = 1.0f;
        }
    }

    public void takeDamage(float damage)
    {
        curHealth -= damage;
        healthBar.SetHealth(curHealth);

        Debug.Log("current health: " + curHealth);

        // check if he is dead
        if (curHealth <= 0) {
            Debug.Log("game over");
            gameOverText.SetActive(true);
            Time.timeScale = 0;
        }

    }

}