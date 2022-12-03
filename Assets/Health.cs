using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] private int health = 20;
    private int MAX_HEALTH = 20;
    Animator anim;

    private void Start() {
        health = MAX_HEALTH;
        anim = GetComponent <Animator> ();
    }

    public void Damage(int amount) {
        this.health -= amount;
        Debug.Log(this.health);

        if (this.health <= 0) {
            anim.SetTrigger("Death");
            Die();
            StartCoroutine(waiter());
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
        RandomSpawner.enemiesAlive--;
    }

    IEnumerator waiter() 
    {
         yield return new WaitForSeconds (1f);
         Destroy(gameObject);
    }
}