using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAI : Enemy
{
    Node parentNode; //Parent node/link

    void Start()
    {
        Node stalkSelector = new Selector();
        Node howlSequence = new Sequencer();

        parentNode = new Selector(); //Creates the new parent node 
        parentNode.nodes.Add(new InRange(playerReference, range));
        parentNode.nodes[0].nodes.Add(stalkSelector); //accesssing the first sequence by checking the 1st element

        stalkSelector.nodes.Add(new Stalk());
        stalkSelector.nodes.Add(howlSequence);

        howlSequence.nodes.Add(new Howl());
        howlSequence.nodes.Add(new StandGround());
        howlSequence.nodes.Add(new Flee());

        parentNode.nodes.Add(new Patrol());
        
        /* parentNode.nodes[0].nodes.Add(new Selector());
        parentNode.nodes[0].nodes.Add(new Stalk());
        parentNode.nodes[0].nodes.Add(new Sequencer());*/

       /* parentNode.nodes[1].nodes.Add(new Howl());
        parentNode.nodes[1].nodes.Add(new StandGround());
        parentNode.nodes[1].nodes.Add(new Flee());*/

    }

    public void Update()
    {
        parentNode.Execute(this); 
    }
}
