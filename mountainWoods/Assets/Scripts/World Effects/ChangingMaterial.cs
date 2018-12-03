using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingMaterial : MonoBehaviour
{

    [HeaderAttribute("[Fir Tree A]")]

    public Material[] materialsFirA;
    MeshRenderer[] meshrenders;
    GameObject[] firTreeA;

    [HeaderAttribute("[Fir Tree B]")]

    public Material[] materialsFirB;
    GameObject[] firTreeB;

    [HeaderAttribute("[Fir Tree C]")]

    public Material[] materialsFirC;
    GameObject[] firTreeC;

    [HeaderAttribute("[Islands]")]
    GameObject[] islandObjects;
    public Material[] IslandMaterials;

    void Start()
    {
        islandObjects = GameObject.FindGameObjectsWithTag("island");
        firTreeA = GameObject.FindGameObjectsWithTag("FirTreeA");
        firTreeB = GameObject.FindGameObjectsWithTag("FirTreeB");
        meshrenders = new MeshRenderer[firTreeA.Length + firTreeB.Length + islandObjects.Length];

        for (int i = 0; i < firTreeA.Length + firTreeB.Length + islandObjects.Length; i++)
        {
            if (i < firTreeA.Length)
                meshrenders[i] = firTreeA[i].GetComponent<MeshRenderer>();
            else
                meshrenders[i] = islandObjects[(firTreeA.Length + +firTreeB.Length+ islandObjects.Length) - i - 1].GetComponent<MeshRenderer>();
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            for (int i = 0; i < meshrenders.Length; i++)
            {
                print("ispressed");

                if (meshrenders[i].tag == "FirTreeA")
                    meshrenders[i].materials = materialsFirA;

                else if (meshrenders[i].tag == "FirTreeB")
                    meshrenders[i].materials = materialsFirB;

                else if (meshrenders[i].tag == "island")
                    meshrenders[i].materials = IslandMaterials;
            }
        }
    }




}