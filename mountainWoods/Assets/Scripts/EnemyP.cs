using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyP : MonoBehaviour {
    public float speed;
    public Transform[] checkpoints;
    private int currentPoint;
    Vector3 Target;
    Vector3 moveDirection;
    // Use this for initialization
    void Start ()
    {
      
    }
	// Update is called once per frame
	void Update ()
    {
        transform.position = Vector3.MoveTowards(transform.position, checkpoints[currentPoint].position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, checkpoints[currentPoint].position) < 0.2f)
        {
            Target = checkpoints[currentPoint].position;
            moveDirection = Target - transform.position;
            

            if(moveDirection.magnitude < 1)
            {
                currentPoint++;
            }
        }
        transform.LookAt(Target);
    }
}
