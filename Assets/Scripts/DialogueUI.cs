using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DialogueUI : MonoBehaviour
{
    [SerializeField] private TMP_Text textLabel;

    private void Start()
    {
        GetComponent<TypewriterEffect>().Run(textToType: "Broccoli: This is a bit of text!\nHello.", textLabel);
    }
}
