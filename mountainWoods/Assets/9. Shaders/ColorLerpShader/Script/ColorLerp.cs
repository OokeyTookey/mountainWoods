using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]

public class ColorLerp : MonoBehaviour {

	[SerializeField] private Transform ColorChangePoint;
	[Range(0,100)][SerializeField] private float lerpValue;
	
	// Update is called once per frame
	void Update () {
		Shader.SetGlobalFloat("_FadeRange", lerpValue);
		Shader.SetGlobalVector("_PlayerPosition", new Vector4(ColorChangePoint.position.x,ColorChangePoint.position.y,ColorChangePoint.position.z, 0));
	}
}
