using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee : MonoBehaviour {
    public Transform targetPosition;
    Rigidbody RB;
    Vector3 desiredVelo;
    public float maxVelo;
    Vector3 steering;

    public GameObject cube;

	void Start ()
    {
        RB = GetComponent<Rigidbody>();

	}
	
	
	void Update ()
    {
        desiredVelo = (targetPosition.position - transform.position).normalized * maxVelo;
        steering = desiredVelo - RB.velocity;
        RB.velocity = Vector3.ClampMagnitude(RB.velocity, 3);

        RB.AddForce(steering);

        //Truncate is clamping- arrival 
        // look where current velocity is
     
        
    }
}
