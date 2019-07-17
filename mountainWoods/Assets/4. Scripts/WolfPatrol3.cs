using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfPatrol3 : MonoBehaviour {

    int index;
    public bool followPlayer;
    public GameObject[] patrolPositions;
    public GameObject playerReference;
    Vector3 offtset;
    public int force;

    void Update ()
    {
        offtset = new Vector3(playerReference.transform.position.x, playerReference.transform.position.y, playerReference.transform.position.z);

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

        if (!followPlayer)
        {
            transform.LookAt(patrolPositions[index].transform.position);
            transform.position = Vector3.MoveTowards(transform.position, patrolPositions[index].transform.position, Time.deltaTime); //Moves towards the temp current waypoint
        }

        if (followPlayer)
        {
            transform.LookAt(offtset);
            transform.position = Vector3.MoveTowards(transform.position, playerReference.transform.position, Time.deltaTime * force);
            Debug.Log("follwingPlayer");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            followPlayer = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            followPlayer = false;
        }
    }
}


