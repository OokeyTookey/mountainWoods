using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnnaCameraController : MonoBehaviour {

    //Consts
    const int MAXANGLEX = 30; //75
    const int MINANGLEX = 300; //285
    const int EYELEVEL = 180;

    //Floats
    public float cursorSensitivity;

    //References
    public Rigidbody playerRB;
    public Transform cameraTransform;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Time.timeScale == 1)
        {
            CameraMovementMouse();
        }
    }

    void CameraMovementMouse()
    {
        cursorSensitivity = 3;

        float MouseX = Input.GetAxis("Mouse X") * cursorSensitivity; //Gets the mouse X axis
        float MouseY = Input.GetAxis("Mouse Y") * cursorSensitivity; //Gets the mouse Y axis

        cameraTransform.Rotate(-MouseY, 0, 0, Space.Self); //makes the camera rotate up and down
        transform.Rotate(0, MouseX, 0, Space.World); //Makes the camera rotate right and left

        float xAxisAngle = cameraTransform.localRotation.eulerAngles.x; //Gets the camera's local X rotation

        if (xAxisAngle >= MAXANGLEX && xAxisAngle < EYELEVEL) //Caps the camera if between 75 and 180
            xAxisAngle = MAXANGLEX;

        else if (xAxisAngle < MINANGLEX && xAxisAngle > EYELEVEL) //Caps the camera if between 285 and 180
            xAxisAngle = MINANGLEX;

        cameraTransform.localRotation = Quaternion.Euler(xAxisAngle, 0, 0);
    }
}
