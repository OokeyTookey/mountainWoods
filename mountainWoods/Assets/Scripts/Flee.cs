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
        /*desiredVelo = (targetPosition.position - transform.position).normalized * maxVelo;
        steering = desiredVelo - RB.velocity;
        RB.velocity = Vector3.ClampMagnitude(RB.velocity, 3);

        RB.AddForce(-steering);*/

        //Truncate is clamping- arrival 
        // look where current velocity is
        //--------------------------------------------------------------------------------------------------------------------------

        //Vector3 dir = (targetPosition.position - transform.position).normalized;

        //desiredVelo = dir * maxVelo;
        //steering = desiredVelo - RB.velocity;
        //RB.velocity = Vector3.ClampMagnitude(RB.velocity, 5);

        //transform.LookAt(new Vector3(targetPosition.position.x, targetPosition.position.y, targetPosition.position.z));

        //transform.position -= transform.forward * 2.0f * Time.deltaTime;
        //RB.AddForce(-desiredVelo);

        /* Vector3 dir = new Vector3(targetPosition.position.x, targetPosition.position.y, targetPosition.position.z);
         dir.Normalize();

         transform.LookAt(new Vector3(-dir.x, -dir.y, -dir.z));
         Debug.DrawRay(transform.position, new Vector3(-dir.x, -dir.y, -dir.z) * 1000);*/

        //transform.rotation = targetPosition.rotation;


        if (Vector3.Distance(transform.position, targetPosition.position) < 10)
        {
            Vector3 dir = (transform.position - targetPosition.transform.position);
            dir.Normalize();

            float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;

            angle = Mathf.Lerp(angle - 45, angle + 45, Time.deltaTime * 10.0f);
            transform.rotation = Quaternion.Euler(0, angle, 0);
            print(angle);

            //transform.LookAt(new Vector3(dir.x, 0.075f, dir.z) * 1000);

            //Debug.DrawRay(transform.position, dir * 1000);

            transform.position += transform.forward * 2.0f * Time.deltaTime;
        }
        
    }
}
