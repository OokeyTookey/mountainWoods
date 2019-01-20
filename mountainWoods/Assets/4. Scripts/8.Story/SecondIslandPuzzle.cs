using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondIslandPuzzle : MonoBehaviour
{
    CameraTweenMainMenu cameraTweenMainMenu;
    TypingText typingTextScript;

    string[] currentTextArray;
    public string[] introductionTextsFisherman;
    public GameObject fishermanPanel;
    int counter;
    bool talkingToFisherMan;

    void Start()
    {
        cameraTweenMainMenu = FindObjectOfType<CameraTweenMainMenu>();
        typingTextScript = fishermanPanel.GetComponentInChildren<TypingText>();
        fishermanPanel.SetActive(false);
    }

    void Update()
    {
        if (talkingToFisherMan)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (counter < currentTextArray.Length - 1) //Scrolls through the text array
                {
                    counter++;
                    typingTextScript.SetText(currentTextArray[counter]);
                }

                if (counter >= currentTextArray.Length - 1) //If finished the array then go back to camera using coroutine
                {
                    StartCoroutine(WaitForLikeAMilasecondToJumpBackToPlayerBecauseTheyKeepSkippingText());
                }
            }
        }
    }

    void FisherManIntro()
    {
        fishermanPanel.SetActive(true);
        currentTextArray = introductionTextsFisherman;
        typingTextScript.SetText(currentTextArray[0]);
        talkingToFisherMan = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FisherManIntro();
            cameraTweenMainMenu.StartWithFisherman();
        }
    }

    private IEnumerator WaitForLikeAMilasecondToJumpBackToPlayerBecauseTheyKeepSkippingText()
    {
        yield return new WaitForSeconds(4f);
        fishermanPanel.SetActive(false);
        cameraTweenMainMenu.ReturnToPlayer();
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }
}
