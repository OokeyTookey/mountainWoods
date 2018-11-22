using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderAI : MonoBehaviour {
    public float circleRadius;
    public float circleDistance;
    public float speed;
    public float angleChange;
    public float force;
    public float mass;

    private float wAngle;

    Vector3 velocity = Vector3.forward;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        var steering = GetWanderForce();
        steering = Vector3.ClampMagnitude(velocity + steering, speed);
        steering /= mass;

        velocity = Vector3.ClampMagnitude(velocity + steering, speed);
        transform.position += velocity;
        transform.forward = velocity;
    }

    private Vector3 GetWanderForce()
    {
        var circleCenter = velocity.normalized * circleDistance;

        var displacement = transform.right * Mathf.Cos(wAngle * Mathf.Deg2Rad) * circleRadius; //new Vector3(1, 2);
        displacement += transform.up * Mathf.Sin(wAngle * Mathf.Deg2Rad) * circleRadius; //.Scale(velocity);

        wAngle += (Random.value * angleChange) - (angleChange * 0.5f);

        var wanderForce = circleCenter + displacement;
        return wanderForce;
    }
}
