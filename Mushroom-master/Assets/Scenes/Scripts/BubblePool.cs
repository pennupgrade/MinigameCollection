using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubblePool : MonoBehaviour
{
    public static BubblePool bubblePoolInstance;

    [SerializeField]
    private GameObject pooledBubble;

    [SerializeField]
    private GameObject trickPooledBubble;

    private bool notEnoughBubblesinPool = true;

    private List<GameObject> bubbles;
    private BossScript boss;
    private bool clear = false;

    private void Awake()
    {
        bubblePoolInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        bubbles = new List<GameObject>();
        boss = FindObjectOfType<BossScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (boss.getIsEnraged() && !clear)
        {
            clear = true;
            bubbles = new List<GameObject>();
            notEnoughBubblesinPool = true;
        }
    }

    public GameObject getBubble()
    {
        if (bubbles.Count > 500)
        {
            notEnoughBubblesinPool = false;
        }

        if (bubbles.Count > 0)
        {
            for (int i = 0; i < bubbles.Count; i++)
            {
                if (!bubbles[i].activeInHierarchy)
                {
                    return bubbles[i];
                }
            }
        }

        if (notEnoughBubblesinPool)
        {
            GameObject bubbleInstance;
            if (boss.getIsEnraged())
            {
                int random = Random.Range(0, 5);
                if (random == 0)
                {
                    bubbleInstance = Instantiate(trickPooledBubble, this.gameObject.transform);
                } else
                {
                    bubbleInstance = Instantiate(pooledBubble, this.gameObject.transform);
                }
            } else
            {
                bubbleInstance = Instantiate(pooledBubble, this.gameObject.transform);
            }
            bubbleInstance.SetActive(false);
            bubbles.Add(bubbleInstance);
            return bubbleInstance;
        }

        return null;
    }
}
