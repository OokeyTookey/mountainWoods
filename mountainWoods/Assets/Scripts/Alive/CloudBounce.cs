using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBounce : MonoBehaviour
{


    Vector3 startLocation;

    Vector3 upLocation;
    Vector3 downLocation;
    float distance;

    public Vector3 movement;
    public float speed;

    void Start()
    {
        //startLocation = transform.position;
    }


    void Update()
    {
        downLocation = -movement;
        upLocation = movement;

        distance = Vector3.Distance(transform.position, upLocation);
        transform.position += upLocation * speed * Time.deltaTime;

        if (distance <=0)
        {
            Debug.Log("help");
            transform.position += downLocation * speed * Time.deltaTime;
        }

    }
}   
