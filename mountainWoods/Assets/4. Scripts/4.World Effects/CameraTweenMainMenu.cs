using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTweenMainMenu : MonoBehaviour
{
    Transform currentView;
    public Transform[] views;
    public Camera playerCamera;
    public CameraFPS mouseMovement;
    public bool isPressed;
    public bool returnPressed;
    public float transitionSpeed;
    private IEnumerator coroutine;

    void Start()
    {
        playerCamera.enabled = true;
        currentView = views[0];
    }

    public void GoToFarmer()
    {
        currentView = views[1];
        mouseMovement.lockCamera = true;
        isPressed = true;
    }

    public void ReturnToPlayer()
    {
        currentView = views[0];
        mouseMovement.lockCamera = false;
        returnPressed = true;
    }

    void LateUpdate()
    {
        if (isPressed  || returnPressed)
        {
            transform.position = Vector3.Lerp(transform.position, currentView.position, Time.deltaTime * transitionSpeed);
            transform.rotation = Quaternion.Slerp(transform.rotation, currentView.transform.rotation, Time.deltaTime * transitionSpeed);
            Debug.Log("trasition");
        }
    }
}