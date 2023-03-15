using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveCounter : MonoBehaviour
{
    int curWave = 0;
    Text counterText;

    // Start is called before the first frame update
    void Start()
    {
        counterText = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        counterText.text = "Wave " + curWave;
    }

    public int Increment()
    {
        curWave++;
        return curWave;
    }
}
