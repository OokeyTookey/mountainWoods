using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondIslandPuzzle : MonoBehaviour
{
    CameraTweenMainMenu cameraTweenMainMenu;
    TypingText typingTextScript;

    public string[] introductionTexts;
    public GameObject fishermanPanel;

    void Start()
    {
        cameraTweenMainMenu = FindObjectOfType<CameraTweenMainMenu>();
        typingTextScript = fishermanPanel.GetComponentInChildren<TypingText>();
        fishermanPanel.SetActive(false);
    }


    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            cameraTweenMainMenu.StartWithFisherman();

        }

    }
}
