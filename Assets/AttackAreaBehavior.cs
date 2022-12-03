using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAreaBehavior : MonoBehaviour
{

    private int damage = 10;

    private void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("attacking");
        
        if(collision.gameObject.TryGetComponent<Health>(out Health enemyComponent)) {
            enemyComponent.Damage(damage);
        }
        /*
        if (collision.GetComponent<Health>() != null) {

            Health h = collider.GetComponent<Health>();
            h.Damage(damage);
        }*/
    }
}