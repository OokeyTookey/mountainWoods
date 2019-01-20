using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfPatrol : MonoBehaviour {

    public GameObject[] wolfLocations;
    public GameObject playerReference;
    int index;
    public bool followPlayer;
    float force = 5;

    void Start ()
    {
        
	}
	
	void Update ()
    {
        if (Vector3.Distance(transform.position, wolfLocations[index].transform.position) <= 1)
        {
            if (index < wolfLocations.Length - 1)
            {
                index++;

            }
            else index = 0;
        }

        if (!followPlayer)
        {
            transform.LookAt(wolfLocations[index].transform.position);
            transform.position = Vector3.MoveTowards(transform.position, wolfLocations[index].transform.position, Time.deltaTime); //Moves towards the temp current waypoint
        }

        if (followPlayer)
        {
            transform.LookAt(playerReference.transform.position);
            transform.position = Vector3.MoveTowards(transform.position, playerReference.transform.position, Time.deltaTime) * force;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            followPlayer = true;
            Debug.Log("help");
        }
    }
}

