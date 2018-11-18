using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingMaterial : MonoBehaviour
{

    [HeaderAttribute("[trees]")]

    public Material[] materials;
    MeshRenderer[] meshrenders;
    GameObject[] greenObjects;

    [HeaderAttribute("[Islands]")]
    GameObject[] islandObjects;
    public Material[] IslandMaterials;

    void Start()
    {
        islandObjects = GameObject.FindGameObjectsWithTag("island");
        greenObjects = GameObject.FindGameObjectsWithTag("green");
        meshrenders = new MeshRenderer[greenObjects.Length + islandObjects.Length];

        for (int i = 0; i < greenObjects.Length + islandObjects.Length; i++)
        {
            if (i < greenObjects.Length)
                meshrenders[i] = greenObjects[i].GetComponent<MeshRenderer>();
            else
                meshrenders[i] = islandObjects[(greenObjects.Length + islandObjects.Length) - i - 1].GetComponent<MeshRenderer>();
        }

        print("??!");
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            for (int i = 0; i < meshrenders.Length; i++)
            {
                print("ispressed");

                if (meshrenders[i].tag == "green")
                    meshrenders[i].materials = materials;

                else if (meshrenders[i].tag == "island")
                    meshrenders[i].materials = IslandMaterials;
            }
        }
    }




}