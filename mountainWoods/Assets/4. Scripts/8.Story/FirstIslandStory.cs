using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstIslandStory : MonoBehaviour
{

    int counter;
    bool talkingToFarm = false;
    TypingText typingTextScript;
    CameraTweenMainMenu cameraTweenMainMenu;
    public GameObject backGroundPanel;
    public string[] currentTextArray;
    public string[] farmerSpeechLostSheep;

    void Start()
    {
        backGroundPanel.SetActive(false);
        cameraTweenMainMenu = FindObjectOfType<CameraTweenMainMenu>();
        typingTextScript = backGroundPanel.GetComponentInChildren<TypingText>();

    }

    void Update()
    {
        if (talkingToFarm)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (counter < currentTextArray.Length - 1)
                {
                    counter++;
                    typingTextScript.SetText(currentTextArray[counter]);
                }

                if (counter >= currentTextArray.Length - 1)
                {
                    StartCoroutine(WaitForLikeAMilasecondToJumpBackToPlayerBecauseTheyKeepSkippingText());
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        print(other.tag);
        if (other.gameObject.tag == "FarmerStory1")
        {
            talkingToFarm = true;
            cameraTweenMainMenu.GoToFarmer();
            FarmerIntro();
        }
    }

    void FarmerIntro()
    {
        backGroundPanel.SetActive(true);
        currentTextArray = farmerSpeechLostSheep;
        typingTextScript.SetText(currentTextArray[0]);
    }

    private IEnumerator WaitForLikeAMilasecondToJumpBackToPlayerBecauseTheyKeepSkippingText()
    {
        yield return new WaitForSeconds(4f);
        backGroundPanel.SetActive(false);
        cameraTweenMainMenu.ReturnToPlayer();
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }
}