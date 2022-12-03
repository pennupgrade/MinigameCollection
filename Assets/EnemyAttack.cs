using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Transform playerTransform;
    public LayerMask playerLayer;
    public float attackRange = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        /* if (Gameobject.FindGameObjectWithTag("Player").activeHierarchy) {
            playerTransform = Gameobject.FindGameObjectWithTag("Player").transform;
        } */
    }

    // Update is called once per frame
    void Update()
    {
        /* if(Input.GetMouseButtonDown(0)) {
            Attack();
        }
        /*
        if (attacking) {
            timer += Time.deltaTime;

            if(timer >= timeToAttack) {
                timer = 0;
                attacking = false;
                attackArea.SetActive(attacking);
            }
        }*/
    }

 /*   private void Attack() {

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemyLayer);
        if (hitEnemies != null) {
            foreach (Collider2D enemy in hitEnemies) {
            Debug.Log("attack");
            enemy.GetComponent<Health>().Damage(10);
        }
        }
        /*
        attacking = true;
        attackArea.SetActive(attacking);
     */
}
