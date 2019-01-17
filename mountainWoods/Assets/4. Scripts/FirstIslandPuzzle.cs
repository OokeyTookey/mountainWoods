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

    void Start()
    {
        Sheep = GameObject.FindGameObjectsWithTag("Sheep");
        Vector3 fixedFencePosition = new Vector3(-102f, 181f, -31f);
    }

    void Update()
    {
        numberOfSheep = Sheep.Length;
        Debug.Log("Total Sheep " + numberOfSheep + "Current in pen" + currentNumberOfSheep);
        if (currentNumberOfSheep >= numberOfSheep)
        {
            Debug.Log("<color=>You saved all my sheep!</color>");
            //finishedFenceGO.transform.position.y = fixedFencePosition;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        currentNumberOfSheep++;
    }

    private void OnTriggerExit(Collider other)
    {
        currentNumberOfSheep--;
    }
}