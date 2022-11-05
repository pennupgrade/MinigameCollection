using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour 
{
    private float curHealth = 1.0f;

    public HealthBar healthBar;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            takeDamage(0.1f);
        }
    }

    public void takeDamage(float damage)
    {
        curHealth -= damage;
        healthBar.SetHealth(curHealth);
    }

}