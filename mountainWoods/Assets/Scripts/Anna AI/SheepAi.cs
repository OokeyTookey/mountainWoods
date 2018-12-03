using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepAi : MonoBehaviour
{

    float currentRotation;
    float oppositeRotation;
    bool collidedOrNot = false;
    float turnSpeed=1;
    Vector3 direct;
    Time timer;
    public GameObject playerGO;
    bool isTouched;
    Vector3 direction;



    void Start()
    {
            currentRotation = transform.rotation.eulerAngles.y;
    }

    void Update()
    {
        transform.Translate((Vector3.forward * Time.deltaTime));
        if (isTouched)
        {

        this.transform.LookAt(direction);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        /*if (collision.gameObject.tag == "sheepObjectCollision")
        {
            Debug.Log("Sheep Collided");
            currentRotation = -currentRotation;
            transform.Rotate(0, currentRotation, 0);
        }

        if (collision.gameObject.tag == "player")
        {

            direction = playerGO.transform.forward;
            isTouched = true;
           
            Debug.Log("print something");
        }*/
    }

 
}
