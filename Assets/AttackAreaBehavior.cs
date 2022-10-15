using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAreaBehavior : MonoBehaviour
{

    private int damage = 10;

    private void OnTriggerEnter2D(Collider2D collider) {
        Debug.Log("attacking");
        if (collider.GetComponent<Health>() != null) {

            Health h = collider.GetComponent<Health>();
            h.Damage(damage);
        }
    }
}
