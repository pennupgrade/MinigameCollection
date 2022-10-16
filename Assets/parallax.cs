using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class parallax : MonoBehaviour
{
    public float timeScale;
    float length;
    float startX;

    // Start is called before the first frame update
    void Start()
    {
        startX = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        var copy = transform.position;
       
        if (copy.x + length < startX)
        {
            copy.x = startX;
        }

        copy.x = copy.x + Manager.velocityX * -Time.deltaTime * timeScale;

        transform.position = copy;
    }
}
