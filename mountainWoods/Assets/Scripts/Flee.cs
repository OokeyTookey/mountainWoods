using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee : MonoBehaviour {
    public Transform targetPosition;
    Rigidbody RB;
    Vector3 desiredVelo;
    public float maxVelo;
    Vector3 steering;
    
	void Start ()
    {
        RB = GetComponent<Rigidbody>();
	}
	
	
	void Update ()
    {
        desiredVelo = (targetPosition.position - transform.position).normalized * maxVelo;
        steering = desiredVelo - RB.velocity;

        RB.AddForce(steering);
 
        //Truncate is clamping- arrival 
        // look where current velocity is
    }
}
