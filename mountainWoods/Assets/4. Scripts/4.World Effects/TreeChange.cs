using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeChange : MonoBehaviour {

    public string firATag;
    public string firBTag;
    public string firCTag;
    public string firDTag;

    int numberOfChildren;

    void Start ()
    {

        /*firTreeA = GameObject.FindGameObjectsWithTag(firATag);
        firTreeB = GameObject.FindGameObjectsWithTag(firBTag);
        firTreeC = GameObject.FindGameObjectsWithTag(firATag);
        firTreeD = GameObject.FindGameObjectsWithTag(firBTag);*/
    }
	
	/*void Update ()
    {
        numberOfChildren = transform.childCount;

        for (int i = 0; i < numberOfChildren; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;

            Renderer renderer = child.GetComponent<Renderer>();

            child.GetComponent<Renderer>().materials = ;

        }

    }*/
}
