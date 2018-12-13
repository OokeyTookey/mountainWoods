using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepAIDemoPurpose : MonoBehaviour {


    public Transform playerReference;

    //----------- Wander Vairables
    Rigidbody RB;
    Vector3 displacement;
    Vector3 circleCenter;
    public float circleRadius; //Vector 3 with specific magnintiude but random direction
    public float offset;

    //----------- Seek Variables
    Vector3 steering;
    Vector3 desiredVelo;
    float distanceFrom;
    float desiredDistance;
    public float maxVelo;

    //----------- Flee Varaibles
    public Transform targetPosition1;
    public float slowingRadius;

    void Start()
    {
        RB = GetComponent<Rigidbody>(); //Angle shift (limit the angle) RAYCAST a random direction (either side)to aviod the 
    }

    void Update()
    {
        /*if (Vector3.Distance(transform.position, playerReference.position) < 20)
        {
            distanceFrom = (transform.position - targetPosition1.position).magnitude; //Calculates the distance between the sheep and position
            desiredVelo = (transform.position - targetPosition1.position).normalized * maxVelo; //Get the desired velocity for flee by minusing the target positions (in this case the player) from the attached objects position

            if (distanceFrom > slowingRadius)
            {
                desiredVelo = Vector3.zero;
            }

            steering = desiredVelo - RB.velocity; //Sets the steering behaviour by minusing
            RB.velocity = Vector3.ClampMagnitude(RB.velocity, 3);
            RB.AddForce(steering); //Moves the character based on the set steering behaviour
        }*/

       
            circleCenter = RB.velocity.normalized * offset + transform.position;
            displacement = circleCenter + new Vector3(Random.Range(-100, 100), 0, Random.Range(-100, 100)).normalized * circleRadius;
            Seek(displacement);
    }

    void Seek(Vector3 targetPosition)
    {
        distanceFrom = (targetPosition - transform.position).magnitude; //Calculates the distance between the sheep and position
        desiredVelo = (targetPosition - transform.position).normalized * maxVelo; //Get the desired velocity for flee by minusing the target positions (in this case the player) from the attached objects position

        steering = desiredVelo - RB.velocity; //Sets the steering behaviour by minusing
        RB.velocity = Vector3.ClampMagnitude(RB.velocity, 3);
        RB.AddForce(steering); //Moves the character based on the set steering behaviour
    }
}