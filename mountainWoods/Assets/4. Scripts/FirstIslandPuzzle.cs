using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstIslandPuzzle : MonoBehaviour
{
    bool movefence;
    public GameObject finishedFenceGO;

    GameObject[] Sheep;
    GameObject[] destoryedFence;

    int numberOfSheep;
    public int currentNumberOfSheep = 0;

    Vector3 currentFencePosition;
    Vector3 fixedFencePosition;

    TreeChange colourChangeTree;

    void Start()
    {
        Sheep = GameObject.FindGameObjectsWithTag("Sheep");
        destoryedFence = GameObject.FindGameObjectsWithTag("DESTROYFENCE");
        fixedFencePosition = new Vector3(-102.17f, 181.35f, -31.54f);
        colourChangeTree = GameObject.FindGameObjectWithTag("island1").GetComponent<TreeChange>();
    }

    void Update()
    {
        numberOfSheep = Sheep.Length;
        if (currentNumberOfSheep >= numberOfSheep)
        {
            finishedFenceGO.transform.position = Vector3.Lerp(finishedFenceGO.transform.position, fixedFencePosition, Time.deltaTime* 2);
            for (int i = 0; i < destoryedFence.Length; i++)
            {
                destoryedFence[i].transform.position = Vector3.Lerp(destoryedFence[i].transform.position, Vector3.zero, Time.deltaTime * 0.001f);
            }
            colourChangeTree.PuzzleComplete();
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