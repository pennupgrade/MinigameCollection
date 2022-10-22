using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int hitsNeeded = 3;
    public int hitsTaken;
    public int transitionSpeed = 40;
    //public GameObject leftCollPoint;
    //public GameObject rightCollPoint;
    public Transform respawnPoint;
    public Transform playerPos;
    public GameObject playerPrefab;

    //public Animator anim;
    //public Animator health;

    //public AudioSource damageAudio;
    //public AudioSource deathAudio;
    //public float volume = 0.5f;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            hitsTaken += 1;
            Vector2 newPos = new Vector2(playerPos.position.x+1, playerPos.position.y+1);
            playerPos.position = Vector2.Lerp(playerPos.position, newPos, Time.deltaTime * transitionSpeed);
       
            //anim.SetTrigger("Dying");
            //damageAudio.PlayOneShot(damageAudio.clip, volume);
        }

        /*if (hitsTaken == 1)
        {
            health.SetTrigger("Health1");
        }
        else if (hitsTaken == 2)
        {
            health.SetTrigger("Health2");
        }
        else if (hitsTaken == 3)
        {
            health.SetTrigger("Health3");
        }*/

        if (hitsTaken >= hitsNeeded)
        {
            //anim.SetTrigger("Dead");
            SelfDestroy();
        }
    }

    public void SelfDestroy()
    {
        playerPos.position = respawnPoint.position;
    }

    /*public void playDeathSound()
    {
        deathAudio.PlayOneShot(deathAudio.clip, volume);
    }*/
}
