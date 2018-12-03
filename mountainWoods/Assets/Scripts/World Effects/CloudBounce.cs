using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBounce : MonoBehaviour
{
    Vector3 startLocation; 
    float distance;

    public Vector3 movement;
    public float speed;

    Vector3 movementDirection;
    Vector3 direction;

    void Start()
    {
        startLocation = transform.position;
        movementDirection = movement;
        direction = movementDirection;
        direction.Normalize();
    }

    void FixedUpdate()
    {
        distance = Vector3.Distance(transform.position, movementDirection + startLocation);

        if (distance <= 0.3f)
        {
            Debug.Log("help PLEASE ");
            direction *= -1;
            movementDirection *= -1;
        }

        transform.position += direction * speed * Time.deltaTime;
    }
}   
