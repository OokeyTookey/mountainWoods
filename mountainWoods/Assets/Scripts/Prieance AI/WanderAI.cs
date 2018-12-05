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
        var displacement = new Vector3(0, -1);
        displacement += Quaternion.LookRotation(velocity) * displacement;

        wAngle += (Random.value * angleChange) - (angleChange * 0.5f);

        var wanderForce = circleCenter + displacement;
        return wanderForce;
    }

    /*public Vector3 setAngle (Vector3 vector,int value)
    {
        var length = new int();
        vector.x = Mathf.Cos(90) * length;
        vector.y = Mathf.Sin(45) * length;
    }*/
}
