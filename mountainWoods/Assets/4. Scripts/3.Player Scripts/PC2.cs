using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriController : MonoBehaviour {
    public float speed;
	// Use this for initialization
	void Start ()
    {
        Cursor.lockState = CursorLockMode.Locked;
	}
	// Update is called once per frame
	void Update ()
    {
        float FB = Input.GetAxis("Vertical") * speed*Time.deltaTime;
        float LR = Input.GetAxis("Horizontal") * speed* Time.deltaTime;
        transform.Translate(LR, 0, FB);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
	}
}
