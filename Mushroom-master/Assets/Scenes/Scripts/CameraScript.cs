using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public PlayerScript player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
        if (this.transform.position.y <= -6)
        {
            this.transform.position = new Vector3(this.transform.position.x, -6, -10);
        } else if (this.transform.position.y >= 1)
        {
            this.transform.position = new Vector3(this.transform.position.x, 1, -10);
        }
    }
}
