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
    public string firATag;
    public string firBTag;
    public string islandTagA; 
    void Start()
    {
        firTreeA = GameObject.FindGameObjectsWithTag(firATag);
        firTreeB = GameObject.FindGameObjectsWithTag(firBTag);
        meshrenders = new MeshRenderer[firTreeA.Length];
     
        int totalLength = firTreeA.Length - 1;
        for (int i = 0; i < firTreeA.Length; i++)
        {
            //meshrenders[i].material.color = Color.white;

            if (i < firTreeA.Length)
            {
                meshrenders[i] = firTreeA[i].GetComponent<MeshRenderer>();
            } 
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            for (int i = 0; i < meshrenders.Length; i++)
            {
                print("ispressed");

                if (meshrenders[i].tag == firATag)
                {
                    meshrenders[i].materials = materialsFirA;
                }

                else if (meshrenders[i].tag == "FirTreeB")
                    meshrenders[i].materials = materialsFirB;

                else if (meshrenders[i].tag == "island")
                    meshrenders[i].materials = IslandMaterials;
            }
        }
    }
}