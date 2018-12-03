using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepMainMenu : MonoBehaviour
{
    public GameObject currentWaypoint;
    public GameObject startingPositionSheep;
    public GameObject endingPositionSheep;

    void Start()
    {

    }

    void Update()
    {

        if (Vector3.Distance(transform.position, currentWaypoint.transform.position) <= 1)
        {
            if (currentWaypoint == endingPositionSheep)
            {
                currentWaypoint = startingPositionSheep;
                transform.Rotate(0, -180, 0); //Rotates the skeleton
            }

            else
            {
                currentWaypoint = endingPositionSheep;
                transform.Rotate(0, 180, 0);
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.transform.position, Time.deltaTime); //Moves towards the temp current waypoint

    }
}
