using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepAi : MonoBehaviour
{

    float currentRotation;
    float oppositeRotation;
    bool collidedOrNot = false;
    float turnSpeed=1;
    

    void Start()
    {
            currentRotation = transform.rotation.eulerAngles.y;
    }

    void Update()
    {
        transform.Translate((Vector3.forward * Time.deltaTime));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "sheepObjectCollision")
        {
            Debug.Log("Sheep Collided");
            currentRotation = -currentRotation;
            transform.Rotate(0, currentRotation, 0);
        }
    }

 
}
