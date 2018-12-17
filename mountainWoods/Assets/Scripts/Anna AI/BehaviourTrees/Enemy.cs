using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float range;
    public Transform playerReference;
    public Rigidbody enemyRB;
    public float offset;

    Node parentNode; //Parent node/link

    //----------- Seek Variables
    Vector3 steering;
    Vector3 desiredVelo;
    float distanceFrom;
    float desiredDistance;
    public float maxVelo;
    public float circleRadius;


    private void Start()
    {
        enemyRB = GetComponent<Rigidbody>();

        parentNode = new Selector();
        parentNode.nodes.Add(new InRange(playerReference, range));
        parentNode.nodes.Add(new Wander());
    }

    public void Update()
    {
        parentNode.Execute(this);  
    }

    public void Seek(Vector3 targetPosition)
    {
        Debug.DrawLine(transform.position, enemyRB.velocity + transform.position, Color.red);

        distanceFrom = (targetPosition - transform.position).magnitude; //Calculates the distance between the sheep and position
        desiredVelo = (targetPosition - transform.position).normalized * maxVelo; //Get the desired velocity for flee by minusing the target positions (in this case the player) from the attached objects position

        steering = desiredVelo - enemyRB.velocity; //Sets the steering behaviour by minusing
        //enemyRB.velocity = Vector3.ClampMagnitude(enemyRB.velocity, maxVelo);
        enemyRB.AddForce(steering); //Moves the character based on the set steering behaviour
    }
}