using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float jumpForce;
    public Rigidbody playerRB;

    // Use this for initialization
    void Start ()
    {
        // this function is called to lock the cursor in game mode
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update ()
    {

        if(Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
	}

    private void FixedUpdate()
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRB.AddForce(transform.up * jumpForce);
        }
    }
}
