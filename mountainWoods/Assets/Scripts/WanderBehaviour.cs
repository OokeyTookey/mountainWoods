using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderBehaviour : MonoBehaviour {
    public float wanderTime;
    public float movementSpeed;
    public float circleDistance;
    private Vector3 velocity;
    //public float wanderAngle;
   
     // Use this for initialization
     void Start ()
     {

     }

     // Update is called once per frame
     void Update ()
     {
        if (wanderTime > 0)
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
}

  
