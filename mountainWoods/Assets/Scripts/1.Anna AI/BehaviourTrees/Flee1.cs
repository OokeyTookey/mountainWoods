using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee1 : Node
{
    Rigidbody RB;
    Vector3 steering;
    Vector3 desiredVelo;
    float distanceFrom;
    float desiredDistance;
    public float slowingRadius;
    public float maxVelo;
    public Transform targetPosition;

  /*  void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        print("Flee");
        Debug.DrawLine(transform.position, RB.velocity + transform.position, Color.yellow);

        distanceFrom = (transform.position - targetPosition.position).magnitude; //Calculates the distance between the sheep and position
        desiredVelo = (transform.position - targetPosition.position).normalized * maxVelo; //Get the desired velocity for flee by minusing the target positions (in this case the player) from the attached objects position

        if (distanceFrom > slowingRadius)
        {
            desiredVelo = Vector3.zero;
        }

        steering = desiredVelo - RB.velocity; //Sets the steering behaviour by minusing
        RB.velocity = Vector3.ClampMagnitude(RB.velocity, 3);
        RB.AddForce(steering); //Moves the character based on the set steering behaviour
    }*/
}