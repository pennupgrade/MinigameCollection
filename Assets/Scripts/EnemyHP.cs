using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyHP : MonoBehaviour
{
    public static event Action<EnemyHP> OnEnemyKilled;
<<<<<<< Updated upstream
    [SerializeField] float health, maxHealth = 1000f;
=======
    [SerializeField] float health, maxHealth = 4f;

    private Animator EnemyAnim;

>>>>>>> Stashed changes
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        EnemyAnim = gameObject.GetComponent<Animator>();
        EnemyAnim.SetBool("Death", false);
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            EnemyAnim.SetBool("Death", true);
            StartCoroutine(Pause());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Pause()
    {
        yield return new WaitForSeconds(0.8f);
        Destroy(gameObject);
        OnEnemyKilled?.Invoke(this);
    }
}
