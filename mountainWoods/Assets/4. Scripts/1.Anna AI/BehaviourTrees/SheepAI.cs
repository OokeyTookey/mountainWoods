using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepAI : Enemy
{
    Node parentNode; //Parent node/link

    void Start()
    {
        parentNode = new Selector(); //Creates the new parent node 
        parentNode.nodes.Add(new InRange(playerReference, range)); //accesssing the first sequence by checking the 1st element
        parentNode.nodes[0].nodes.Add(new Flee()); //Adds flee to the sequence after checking if the player is within range

        parentNode.nodes.Add(new Wander()); //Fallback behaviour is set to wander (if everything fails this will return true)
    }

    public void Update()
    {
        parentNode.Execute(this); 
    }
}