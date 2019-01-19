using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstIslandStory : MonoBehaviour
{
    int counter;
    bool talkingToFarm = false;
    bool sheepIn = false;
    TypingText typingTextScript;
    FirstIslandPuzzle firstIslandScript;
    CameraTweenMainMenu cameraTweenMainMenu;
    public GameObject backGroundPanel;
    string[] currentTextArray;
    public string[] farmerSpeechLostSheep;
    public GameObject farmer;
    public GameObject sheepCountUI;
    Text sheepText;

    void Start()
    {
        if (sheepCountUI != null)
        {
            sheepText = sheepCountUI.GetComponent<Text>();
            sheepCountUI.SetActive(false);
        }

        cameraTweenMainMenu = FindObjectOfType<CameraTweenMainMenu>();
        firstIslandScript = FindObjectOfType<FirstIslandPuzzle>();
        typingTextScript = backGroundPanel.GetComponentInChildren<TypingText>();
        backGroundPanel.SetActive(false);  
    }

    void Update()
    {
        if (sheepCountUI != null)
        {
            sheepText.text = "Sheep Collected: " + firstIslandScript.currentNumberOfSheep + " /5";
        }
            
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

        if (sheepIn)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(SheepIsInPen());
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            talkingToFarm = true;
            cameraTweenMainMenu.GoToFarmer();
            FarmerIntro();

            if (sheepCountUI != null)
                sheepCountUI.SetActive(true);
        }

        if (other.gameObject.tag == "Sheep")
        {
            sheepIn = true;
            farmer.transform.rotation = Quaternion.Euler(new Vector3(farmer.transform.rotation.x, -183.62f, farmer.transform.rotation.z));
            cameraTweenMainMenu.GoToFarmerWithSheep();
            SheepFarmer();
            counter++;
        }
    }

    void FarmerIntro()
    {
        backGroundPanel.SetActive(true);
        currentTextArray = farmerSpeechLostSheep;
        typingTextScript.SetText(currentTextArray[0]);
    }

    void SheepFarmer()
    {
        backGroundPanel.SetActive(true);
        currentTextArray = farmerSpeechLostSheep;
        typingTextScript.SetText(currentTextArray[counter]);
    }

    private IEnumerator WaitForLikeAMilasecondToJumpBackToPlayerBecauseTheyKeepSkippingText()
    {
        yield return new WaitForSeconds(4f);
        backGroundPanel.SetActive(false);
        cameraTweenMainMenu.ReturnToPlayer();
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }

    private IEnumerator SheepIsInPen()
    {
        yield return new WaitForSeconds(1f);
        backGroundPanel.SetActive(false);
        cameraTweenMainMenu.ReturnToPlayer();
    }
}