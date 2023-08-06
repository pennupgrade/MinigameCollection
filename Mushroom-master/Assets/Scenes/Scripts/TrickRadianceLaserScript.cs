using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrickRadianceLaserScript : MonoBehaviour
{
    private float laserDamage = 10;
    public PlayerScript player;
    private float timer = 0.8f;
    private bool rotated = false;

    private BoxCollider2D hitbox;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerScript>();
        hitbox = this.GetComponent<BoxCollider2D>();
        hitbox.enabled = false;
        Destroy(this.transform.parent.gameObject, 1f);
        this.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(0.47f, 0.2f, 1);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timer <= 0)
        {
            hitbox.enabled = true;
            if (!rotated)
            {
                this.transform.parent.gameObject.transform.Rotate(0, 0, 22.5f);
                rotated = true;
            }
        }
        timer -= Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.gameObject.tag == "player")
        {
            player.getHit(laserDamage);
        }
    }
}
