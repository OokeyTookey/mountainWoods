using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour {
    public Transform[] waypoints;
    public float speed;
    public int currentWaypoint;
    public bool isPatrolling = true;
    public Vector3 Target;
    public Vector3 MoveDir;
    public Vector3 Velocity;
    
	// Use this for initialization
	void Start ()
    {
		
	}
	// Update is called once per frame
	void Update ()
    {
        if (currentWaypoint < waypoints.Length)
        {
            Target = waypoints[currentWaypoint].position;
            MoveDir = Target - transform.position;
            Velocity = GetComponent<Rigidbody>().velocity;

            if (MoveDir.magnitude < 1)
            {
                currentWaypoint++;
            }
            else
            {
                Velocity = MoveDir.normalized * speed;
            }
        }
        else
        {
            if (isPatrolling)
            {
                currentWaypoint = 0;
            }
            else
            {
                Velocity = new Vector3(0, 0, 0);
            }
        }
        GetComponent<Rigidbody>().velocity = Velocity;
        transform.LookAt(Target);
        }
	}
