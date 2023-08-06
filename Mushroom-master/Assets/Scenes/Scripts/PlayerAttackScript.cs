using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackScript : MonoBehaviour
{
    private float playerAttack = 2.5f;
    public PlayerScript player;
    public BossScript boss;

    // Start is called before the first frame update
    void Start()
    {
        boss = FindObjectOfType<BossScript>();
        Destroy(this.transform.parent.gameObject, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.gameObject.tag == "boss")
        {
            boss.getHit(playerAttack);
        }
    }
}
