using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWander : MonoBehaviour {
    public float maxSpeed;
    public float circleRadius;
    public float circleDistance;
    float wanderAngle;
    public float angleChange;
    public float maxForce;
    Vector3 circleCenter;
    Vector3 displacement; 
    Vector3 wanderForce;
    Vector3 steering;
    Vector3 velocity = Vector3.forward;
    private Rigidbody rb;
	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        steering = Wander();
        steering = Vector3.ClampMagnitude(steering, maxForce);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity + steering, maxSpeed);
        rb.AddForce(steering);
        print(wanderAngle);
	}

    Vector3 Wander()
    {
        Vector3 circleCenter;
        circleCenter = rb.velocity;
        circleCenter = Vector3.Normalize(circleCenter);
        circleCenter *= (circleDistance);
        circleCenter = velocity.normalized * circleDistance;//clone of velocity vector which is normalized and then multiplied by circleDistance
        displacement = new Vector3(0, 0, -1);
        displacement *= circleRadius;//circleCenter multiplied with circleRadius
        SetAngle(displacement, wanderAngle);
        wanderAngle += Random.Range(0, 1f) * angleChange - angleChange * 0.5f;
        wanderForce = circleCenter + displacement;
        return wanderForce;//the center of the circle + the displacemment
    }

    void SetAngle(Vector3 vector, float value)
    {
        float length = vector.magnitude;
        vector.x = Mathf.Cos(value) * length;
        vector.z = Mathf.Sin(value) * length;
    }
}
