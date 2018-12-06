using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderBehaviour : MonoBehaviour {
    public float circleRadius;
    //public float circleDistance;
    public float speed;
    public float mass;
    public float turnChance;
    public float force;
    public float maxRadius;
    private Vector3 velocity;
    private Vector3 wanderForce;
    private Vector3 target;
    //public float wanderAngle;
   
     // Use this for initialization
     void Start ()
     {
        velocity = Random.onUnitSphere;
        wanderForce = GetRandomWanderForce();
     }

    // Update is called once per frame
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
        
        /*if (wanderTime > 0)
        {
            transform.Translate(Vector3.forward * movementSpeed);
            wanderTime -= Time.deltaTime;
        }
        else
        {
            wanderTime = Random.Range(1f, 2f);
            Wander();
        }
        }

    void Wander()
    {
        transform.eulerAngles = new Vector3(0, Random.Range(0, 360), 0);
    }

    //private Vector3 wander()
    //{
    //    var circleCenter = new Vector3();
    //    circleCenter = velocity.normalized;
    //    circleCenter.Scale(velocity);

    //    var displacement = new Vector3(0, -1);
    //    displacement.Scale(velocity);

    //}
    */


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
        return wanderForoce;
    }
}

  
