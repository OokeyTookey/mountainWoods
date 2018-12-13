using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;

public class NPCFirstIsland : MonoBehaviour
{

    public GameObject TextPanel1;
    public GameObject TextWelcome;
    public GameObject TextControls;
    public GameObject TextSheep;
    bool nextFrame;
    float textCounter;

    void Start()
    {

    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            nextFrame = true;
            textCounter++;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        TextPanel1.SetActive(true);
    }

    private void OnTriggerStay(Collider other)
    {
        if (nextFrame & TextPanel1 & other.gameObject.tag == "Farmer")
        {
            TextWelcome.SetActive(false);
            TextControls.SetActive(true);
        }

        if (nextFrame & TextPanel1 & textCounter == 2)
        {
            TextControls.SetActive(false);
            TextSheep.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        TextPanel1.SetActive(false);
    }
}
