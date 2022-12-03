using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour 
{
    private float curHealth = 1.0f;
    private float invincibilityTimer = 0.0f;

    public HealthBar healthBar;

    void Update() {
        if (invincibilityTimer > 0) {
            invincibilityTimer = Mathf.Max(0.0f, invincibilityTimer - Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && invincibilityTimer == 0)
        {
            takeDamage(0.1f);
            invincibilityTimer = 1.0f;
        }
    }

    public void takeDamage(float damage)
    {
        curHealth -= damage;
        healthBar.SetHealth(curHealth);
    }

}