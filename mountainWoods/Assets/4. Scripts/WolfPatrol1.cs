using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfPatrol1 : MonoBehaviour {

    int index;
    public GameObject[] patrolPositions;

    void Update ()
    {
        transform.position = Vector3.MoveTowards(transform.position, patrolPositions[index].transform.position, Time.deltaTime); //Moves towards the temp current waypoint
        transform.LookAt(patrolPositions[index].transform.position);

        if (Vector3.Distance(transform.position, patrolPositions[index].transform.position) <= 1)
        {
        transform.position = Vector3.MoveTowards(transform.position, patrolPositions[index].transform.position, Time.deltaTime); //Moves towards the temp current waypoint

            if (index < patrolPositions.Length - 1)
            {
                index++;
            }
            else index = 0;
        }
    }
}


