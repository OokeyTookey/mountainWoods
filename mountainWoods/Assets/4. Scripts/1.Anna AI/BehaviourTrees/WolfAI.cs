using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAI : Enemy
{
    Node parentNode; //Parent node/link
    Node stalkSequencer;
    Node howlSequence;

    void Start()
    {
        stalkSequencer = new Sequencer();
        howlSequence = new Sequencer();

        parentNode = new Selector(); //Creates the new parent node 
        parentNode.nodes.Add(new InRange(playerReference, range));
        parentNode.nodes[0].nodes.Add(stalkSequencer); //accesssing the first sequence by checking the 1st element

        stalkSequencer.nodes.Add(new Stalk());
        stalkSequencer.nodes.Add(howlSequence);

        howlSequence.nodes.Add(new Howl());
        howlSequence.nodes.Add(new StandGround());
        howlSequence.nodes.Add(new Flee());

        parentNode.nodes.Add(new Patrol());
    }

    public void Update()
    {
        parentNode.Execute(this); 
    }
}