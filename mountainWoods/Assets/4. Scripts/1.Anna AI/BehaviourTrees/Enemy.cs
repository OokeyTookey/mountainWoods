using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Class Settings")]
    public float range;
    public float offset;
    public float FOV;
    public Transform playerReference;
    public Rigidbody enemyRB;
    public float force;
    public float fleeForce;
    public float collisionRange;
    public GameObject poopPrefabulous;

    [Header("Seek Variables")]
    public float distanceFrom;
    public float desiredDistance;
    public float maxSpeed;
    public float circleRadius;
    Vector3 steering;
    Vector3 desiredVelo;
    RaycastHit hit;

    public float slowingRadius;

    public void Seek(Vector3 targetPosition) //Generic seek code between this object and another position (usually the player)
    {
        Debug.DrawLine(transform.position, enemyRB.velocity + transform.position, Color.red); //Debugging purposes.
        desiredVelo = (targetPosition - transform.position).normalized * maxSpeed; //Get the desired velocity for flee by minusing the target positions (in this case the player) from the attached objects position
        steering = desiredVelo - enemyRB.velocity; //Sets the steering behaviour by minusing

        enemyRB.AddForce(new Vector3(steering.x, 0, steering.z) * force); //Moves the character based on the set steering behaviour
                                                                          // Ray rayFromEnemy = new Ray(transform.position + transform.forward * 1.5f, transform.forward);
        Ray rayFromEnemy = new Ray(transform.position + Vector3.up* 0.5f + transform.forward, transform.forward);

        Debug.DrawRay(rayFromEnemy.origin, transform.forward * collisionRange, Color.yellow);
        if (Physics.Raycast(rayFromEnemy, out hit, collisionRange, LayerMask.GetMask("SheepColliders")))
        {
            Vector3 v = Vector3.Reflect(enemyRB.velocity, hit.normal);
            Debug.DrawRay(hit.point, v, Color.green);
            
            enemyRB.AddForce(v * force);
        }

        if (enemyRB.velocity.magnitude >= maxSpeed)
        {
            enemyRB.velocity = enemyRB.velocity.normalized * maxSpeed; //limit the speed 
        }
        Vector3 lookAhead = enemyRB.velocity;
        lookAhead.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookAhead),0.2f);
    }
}