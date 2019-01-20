using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarterIslandsTexts : MonoBehaviour
{
    public GameObject TextPanel1;
    public GameObject TextWelcome;
    public GameObject TextControls;
    TreeChange changingTheTree;
    bool nextFrame;

    private void Start()
    {
        changingTheTree = GameObject.Find("starterIslandTrees").GetComponent<TreeChange>();
    }

    private void Update()
    {
        /*if (Input.GetKey(KeyCode.Space))
        {
            nextFrame = true;
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        TextPanel1.SetActive(true);
        if (other.gameObject.tag == "Player")
        {
            changingTheTree.PuzzleComplete();
        }
    }

    private void OnTriggerStay(Collider other)
    {
       /* if (nextFrame & TextPanel1)
        {
            TextWelcome.SetActive(false);
            TextControls.SetActive(true);
        }*/
    }

    private void OnTriggerExit(Collider other)
    {
        TextPanel1.SetActive(false);
    }
}