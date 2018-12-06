using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee : MonoBehaviour
{

    Rigidbody RB;
    Vector3 steering;
    Vector3 desiredVelo;
    float distanceFrom;
    float desiredDistance;
    float slowingRadius = 5;
    public float maxVelo;
    public Transform targetPosition;


    void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        distanceFrom = (transform.position - targetPosition.position).magnitude; //Calculates the distance between the sheep and position

        /*if (distanceFrom < 10) //If the player is in range
        {
        }*/
            desiredDistance = desiredVelo.magnitude;
            desiredVelo = -(transform.position - targetPosition.position).normalized * maxVelo; //Get the desired velocity for flee by minusing the target positions (in this case the player) from the attached objects position
            steering = desiredVelo - RB.velocity; //Sets the steering behaviour by minusing
            RB.velocity = Vector3.ClampMagnitude(RB.velocity, 3); 
            RB.AddForce(steering); //Moves the character based on the set steering behaviour

             if (desiredDistance < slowingRadius)
             {
                 desiredVelo = desiredVelo.normalized * maxVelo * (desiredDistance / slowingRadius);
             }
             else
             {
                 // Outside the slowing area.
                 desiredVelo = desiredVelo.normalized * maxVelo;
             }
        print(desiredVelo);
    }
}
