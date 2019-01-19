using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public Rigidbody playerRB;
    CameraFPS mouseMovement;

    void Start()
    {
        mouseMovement = GetComponentInChildren<CameraFPS>();
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
        if (!mouseMovement.lockCamera)
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
}
