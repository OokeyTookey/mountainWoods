using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;

public class StarterIslandsTexts : MonoBehaviour
{
    public GameObject TextPanel1;
    public GameObject TextWelcome;
    public GameObject TextControls;
    bool nextFrame;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            nextFrame = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        TextPanel1.SetActive(true);
    }

    private void OnTriggerStay(Collider other)
    {
        if (nextFrame & TextPanel1)
        {
            TextWelcome.SetActive(false);
            TextControls.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        TextPanel1.SetActive(false);
    }
}