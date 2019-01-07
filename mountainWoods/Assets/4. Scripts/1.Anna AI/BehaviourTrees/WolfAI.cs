using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAI : Enemy
{
    Node parentNode; //Parent node/link
    Node StalkSelector;
    Node howlSequence;

    void Start()
    {
        StalkSelector = new Selector();
        howlSequence = new Sequencer();

        parentNode = new Selector(); //Creates the new parent node 
        parentNode.nodes.Add(new InRange(playerReference, range));
        parentNode.nodes[0].nodes.Add(StalkSelector); //accesssing the first sequence by checking the 1st element

        StalkSelector.nodes.Add(new Stalk());
        StalkSelector.nodes.Add(howlSequence);

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