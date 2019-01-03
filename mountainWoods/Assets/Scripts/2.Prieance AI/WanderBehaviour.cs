using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderBehaviour : MonoBehaviour {

    /*public float circleRadius;
    public float speed;
    public float mass;
    public float turnChance;
    public float force;
    public float maxRadius;

    private Vector3 velocity;
    private Vector3 wanderForce;
    private Vector3 target;
   
     void Start ()
     {
        velocity = Random.onUnitSphere;
        wanderForce = GetRandomWanderForce();
     }

    void Update()
    {
        var desiredVelocity = GetWanderForce();
        desiredVelocity = desiredVelocity.normalized - velocity;

        var steeringForce = desiredVelocity - velocity;
        steeringForce = Vector3.ClampMagnitude(steeringForce, force);
        steeringForce /= mass;

        velocity = Vector3.ClampMagnitude(velocity + steeringForce, speed);
        transform.position += velocity * Time.deltaTime;
        transform.forward = velocity.normalized;

        Debug.DrawRay(transform.position, velocity.normalized * 2, Color.green);
        Debug.DrawRay(transform.position, desiredVelocity.normalized * 2, Color.red);
    }

    private Vector3 GetWanderForce()
    {
        if(transform.position.magnitude > maxRadius)
        {
            var directionToCenter = (target - transform.position).normalized;
            wanderForce = velocity.normalized + directionToCenter;
        }
        else if(Random.value < turnChance)
        {
            wanderForce = GetWanderForce();
        }
        return wanderForce;
    }

    private Vector3 GetRandomWanderForce()
    {
        var circleCenter = velocity.normalized;
        var randomPoint = Random.insideUnitCircle;

        var displacement = new Vector3(randomPoint.x, randomPoint.y) * circleRadius;
        displacement = Quaternion.LookRotation(velocity) * displacement;

        var wanderForoce = circleCenter + displacement;
        return wanderForoce;*/
    }
