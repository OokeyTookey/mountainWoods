﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepAI : Enemy {

    Node parentNode; //Parent node/link


    void Start ()
    {
        enemyRB = GetComponent<Rigidbody>(); //Accesses the enemies rigid body.

        parentNode = new Selector(); //Creates the new parent node 
        parentNode.nodes.Add(new Sequencer()); //Addes a new node to the parent which is the sequencer
        parentNode.nodes[0].nodes.Add(new InRange(playerReference, range)); //accesssing the first sequence by checking the 1st element
        parentNode.nodes[0].nodes.Add(new Flee()); //Adds flee to the sequence after checking if the player is within range

        parentNode.nodes.Add(new Wander()); //Fallback behaviour is set to wander (if everything fails this will return true)
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}