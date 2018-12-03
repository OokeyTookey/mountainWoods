using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    public Rigidbody playerRB;
    public GameObject fenceGate;
    bool fence = false;

 
    void Start()
    {
        
        Cursor.lockState = CursorLockMode.Locked;
    }

  
    void Update()
    {

        if (Input.GetKeyDown("escape"))
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

        if (Input.GetKey(KeyCode.E) && fence)
        {
            fenceGate.transform.Rotate(0, -90, 0);
            fence = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    { 
        if (other.gameObject.tag == "fenceGate")
        {
            fence = true;
        }
    }
    
    
}
