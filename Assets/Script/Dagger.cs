using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dagger : MonoBehaviour
{
    public GameObject daggerPrefab;
    public Vector3 dir;
    public float damage;
    private bool sticked;
    private bool stickedToBoss;
    public GameObject boss;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        sticked = false;
        stickedToBoss = false;
        damage = 10.0f;
        boss = GameObject.FindWithTag("Boss");
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (!sticked)
        {
            this.transform.position += dir * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "boss" && !sticked)
        {
            //stick with boss and lose its velocity
            sticked = true;
            stickedToBoss = true;
            this.transform.SetParent(other.transform);
        } else if (other.tag == "border" && !sticked) {
            sticked = true;
        }
    }

    void KeyPressed()
    {
        if (sticked && stickedToBoss)
        {
            Detonate();
        } else
        {
            Teleport();
        }
        Destroy(gameObject);
    }
    //if dagger is not sticked and pressed, teleport
    private void Teleport()
    {
        //do trail animations and lerp character to the position
        Vector3 pos = this.transform.position;
        //look for player
        //player.GetComponent<PlayerScript>.teleport(pos);
    }
    //if dagger is sticked then detonate
    private void Detonate()
    {
        //give damage to boss
        //look for boss
        boss.GetComponent<Boss>().doDamage(damage);
    }
}
