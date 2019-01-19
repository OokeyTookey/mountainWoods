using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnnaPlayerController : MonoBehaviour {

    public Rigidbody playerRB;
    public int speed;

    private void Start()
    {
        speed = 100;
        playerRB = GetComponent<Rigidbody>();
    }

    void Fixedpdate ()
    {
        if (Input.GetKey(KeyCode.W))
        {
            playerRB.AddForce(transform.forward * speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            playerRB.AddForce(-transform.forward * speed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            playerRB.AddForce(-transform.right * speed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            playerRB.AddForce(transform.right * speed);
        }
    }
}
