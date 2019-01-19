using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstIslandPuzzle : MonoBehaviour
{
    GameObject[] Sheep;
    int numberOfSheep;
    int currentNumberOfSheep = 0;
    bool movefence;
    public GameObject finishedFenceGO;
    Vector3 currentFencePosition;
    Vector3 fixedFencePosition;
    GameObject[] destoryedFence;

    void Start()
    {
        Sheep = GameObject.FindGameObjectsWithTag("Sheep");
        destoryedFence = GameObject.FindGameObjectsWithTag("DESTROYFENCE");
        fixedFencePosition = new Vector3(-102.17f, 181.35f, -31.54f);
    }

    void Update()
    {
        numberOfSheep = Sheep.Length;
        Debug.Log("Total Sheep " + numberOfSheep + "Current in pen" + currentNumberOfSheep);
        if (currentNumberOfSheep >= numberOfSheep)
        {
            Debug.Log("<color=>You saved all my sheep!</color>");
            finishedFenceGO.transform.position = Vector3.Lerp(finishedFenceGO.transform.position, fixedFencePosition, Time.deltaTime* 2);
            for (int i = 0; i < destoryedFence.Length; i++)
            {
                destoryedFence[i].transform.position = Vector3.Lerp(destoryedFence[i].transform.position, Vector3.zero, Time.deltaTime * 0.001f);

            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Sheep")
        {
            currentNumberOfSheep++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Sheep")
        {
            currentNumberOfSheep--;
        }
    }
}