using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourLerp : MonoBehaviour
{
    public Material[] newMaterials;

    int numberOfChildren;

    public float duration = 2.0f;
    Renderer render;
    float lerp;

    void Start ()
    {
        render = GetComponent<Renderer>();
    }
	
	void Update ()
    {
        if (Input.GetKey(KeyCode.P))
        {
            numberOfChildren = transform.childCount;

            lerp = Mathf.PingPong(Time.time, duration) / duration;

            for (int i = 0; i < numberOfChildren; i++)
            {
                GameObject child = transform.GetChild(i).gameObject;

                Renderer renderer = child.GetComponent<Renderer>();
                renderer.material.Lerp(newMaterials[0], newMaterials[1], lerp);








                //child.GetComponent<Renderer>().materials = newMaterials.;

                // render.material.Lerp(newMaterials[0], newMaterials[1], lerp);

            }
        }

        /*for (int i = 0; i < Prefabs.Length; i++)
        {
            Materials = Prefabs[i].GetComponent<MeshRenderer>().materials;
        }*/
    }
}
