using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] private int health = 100;
    private int MAX_HEALTH = 100;

    private void Start() {
        health = MAX_HEALTH;
    }

    public void Damage(int amount) {
        this.health -= amount;
        Debug.Log(this.health);

        if (this.health <= 0) {
            Die();
            Destroy(gameObject);
        }
    }

    public void Heal(int amount) {
        if (this.health + amount > MAX_HEALTH) 
        {
            this.health = MAX_HEALTH;
        } else {
            this.health += amount;
        }
    }

    private void Die() {
        Debug.Log("I am dead");
    }
}