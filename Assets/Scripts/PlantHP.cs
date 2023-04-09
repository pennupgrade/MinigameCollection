using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlantHP : MonoBehaviour
{
    public static event Action<PlantHP> OnPlantKilled;
    [SerializeField] float health, maxHealth = 80f;

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
            OnPlantKilled?.Invoke(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
