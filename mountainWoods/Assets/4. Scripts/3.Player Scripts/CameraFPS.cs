using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFPS : MonoBehaviour {
    Vector2 fpsLook;
    Vector2 smooth;
    GameObject player1;
    public float sensitivity;
    public float smoothness;
    public bool lockCamera = false;

	void Start ()
    {
        //the game object referenced is the child of the game object attached to this file
        player1 = this.transform.parent.gameObject;
        fpsLook = new Vector2(player1.transform.localRotation.eulerAngles.y, player1.transform.localRotation.eulerAngles.x);
    }
	
	void Update ()
    {
        if (!lockCamera)
        {
            if (Time.timeScale >= 1)
            {
                var mouseMov = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

                mouseMov = Vector2.Scale(mouseMov, new Vector2(sensitivity * smoothness, sensitivity * smoothness));
                //this function smoothens out the movement of the camera from one point to another
                smooth.x = Mathf.Lerp(smooth.x, mouseMov.x, 1f / smoothness);
                smooth.y = Mathf.Lerp(smooth.y, mouseMov.y, 1f / smoothness);
                fpsLook += mouseMov;
                //this function clamps the camera vertically to a fixed anglw
                fpsLook.y = Mathf.Clamp(fpsLook.y, -90f, 90f);

                transform.localRotation = Quaternion.AngleAxis(-fpsLook.y, Vector3.right);
                player1.transform.localRotation = Quaternion.AngleAxis(fpsLook.x, player1.transform.up);
            }
        }
	}
}

