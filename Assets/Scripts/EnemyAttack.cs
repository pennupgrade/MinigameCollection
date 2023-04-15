using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EnemyAttack : MonoBehaviour
{
    private bool attackDebounce = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private IEnumerator Debounce()
    {
        attackDebounce = true;
        yield return new WaitForSeconds(0.5f);
        attackDebounce = false;
    }

    //Collision with plant
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!attackDebounce && collision.transform.tag == "PlantHitbox")
        {
            // do damage
            collision.transform.parent.gameObject.GetComponent<PlantHP>().TakeDamage(5);
            StartCoroutine(Debounce());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
