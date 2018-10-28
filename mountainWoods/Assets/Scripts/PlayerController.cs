using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed = 100.0f;

	// Use this for initialization
	void Start ()
    {
        // this function is called to lock the cursor in game mode
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update ()
    {
        float moveHor = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float moveVert = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Translate(moveHor, 0, moveVert);

        if(Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
	} 
}
