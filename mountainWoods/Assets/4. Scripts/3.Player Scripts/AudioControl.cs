using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour {
    AudioSource Audio;
	// Use this for initialization
	void Start () {
        Audio.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        Audio = GetComponent<AudioSource>();
        if (Input.GetKeyDown(KeyCode.W)) {
            Audio.Play(); 
        }
        if (Input.GetKeyUp(KeyCode.W)) {
            Audio.Pause();
        }
	}
}
