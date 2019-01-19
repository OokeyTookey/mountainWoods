using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepInPen : MonoBehaviour {

    public BoxCollider sheepGate;
    AudioSource audioSource;
    float baaTimer;
    float randomBaa;

	void Start ()
    {
        audioSource = GetComponent<AudioSource>();
        Physics.IgnoreCollision(sheepGate, GetComponentInChildren<CapsuleCollider>(), true); //one way wall
        randomBaa = Random.Range(3, 6);
    }

    private void Update()
    {
        baaTimer += Time.deltaTime;

        if (baaTimer >= randomBaa)
        {
            audioSource.Play();
            baaTimer = 0;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "GateTrigger")
        {
            Physics.IgnoreCollision(sheepGate, GetComponentInChildren<CapsuleCollider>(), false);
        }
    }
}