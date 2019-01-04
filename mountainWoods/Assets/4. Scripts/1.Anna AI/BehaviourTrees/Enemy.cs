﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Class Settings")]
    public float range;
    public float offset;
    public Transform playerReference;
    public Rigidbody enemyRB;
    Node parentNode; //Parent node/link

    [Header("Seek Variables")]
    public float distanceFrom;
    public float desiredDistance;
    public float maxVelo;
    public float circleRadius;
    Vector3 steering;
    Vector3 desiredVelo;

    public float slowingRadius;

    private void Start()
    {
        enemyRB = GetComponent<Rigidbody>(); //Accesses the enemies rigid body.
    }

    public void Update()
    {
         
    }

    public void Seek(Vector3 targetPosition) //Generic seek code between this object and another position (usually the player)
    {
        Debug.DrawLine(transform.position, enemyRB.velocity + transform.position, Color.red); //Debugging purposes.

        distanceFrom = (targetPosition - transform.position).magnitude; //Calculates the distance between the sheep and position
        desiredVelo = (targetPosition - transform.position).normalized * maxVelo; //Get the desired velocity for flee by minusing the target positions (in this case the player) from the attached objects position

        steering = desiredVelo - enemyRB.velocity; //Sets the steering behaviour by minusing
        enemyRB.AddForce(steering); //Moves the character based on the set steering behaviour
    }
}