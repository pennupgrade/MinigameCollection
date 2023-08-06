using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleAttackScript : MonoBehaviour
{
    private float bubbleDamage = 5;
    private float velocity = 5;
    private Vector3 dir;
    public PlayerScript player;
    private float timer = 3f;

    private void OnEnable()
    {
        Invoke("Destroy", 3f);
    }

    public void setDir(Vector3 newDir)
    {
        dir = newDir;
    }

    public void setVelocity(float newVelocity)
    {
        velocity = newVelocity;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerScript>();
        dir = Vector3.zero;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += dir * velocity * Time.deltaTime;
        timer -= Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.gameObject.tag == "player")
        {
            player.getHit(bubbleDamage);
        }

        if (hit.gameObject.tag == "player_attack" && timer <= 0)
        {
            Destroy();
        }
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
