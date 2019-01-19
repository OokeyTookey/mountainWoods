using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepInPen : MonoBehaviour {

    public BoxCollider sheepGate;

	void Start ()
    {
        Physics.IgnoreCollision(sheepGate, GetComponentInChildren<CapsuleCollider>(), true); //one way wall
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "GateTrigger")
        {
            Physics.IgnoreCollision(sheepGate, GetComponentInChildren<CapsuleCollider>(), false);
        }
    }
}