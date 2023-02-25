using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyHP : MonoBehaviour
{
    public static event Action<EnemyHP> OnEnemyKilled;
    [SerializeField] float health, maxHealth = 4f;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            Destroy(gameObject);
            OnEnemyKilled?.Invoke(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
