using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehavior : MonoBehaviour
{
    public Transform attackPos;
    public LayerMask enemyLayer;
    public float attackRange = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        //attackArea = transform.GetChild(0).gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) {
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

    private void Attack() {

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemyLayer);
        if (hitEnemies != null) {
            foreach (Collider2D enemy in hitEnemies) {
            Debug.Log("attack");
            enemy.GetComponent<Health>().Damage(10);
            enemy.GetComponent<EnemyMovement>().bounceBack();
        }
        }
        /*
        attacking = true;
        attackArea.SetActive(attacking);*/
    }
}