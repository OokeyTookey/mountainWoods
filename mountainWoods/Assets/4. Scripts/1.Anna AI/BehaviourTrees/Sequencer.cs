using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequencer : Node {
    public override Result Execute(Enemy owner)
    {
        for (int i = 0; i < nodes.Count; i++)
        {
            if (previousResult == Result.running && nodes[i].previousResult!=Result.running)
            {
                continue; //Skips an itteration in the for loops
            }

            nodes[i].Execute(owner);

            if (nodes[i].Execute(owner) == Result.failure)
            {
                return previousResult = Result.failure;
            }

            if (nodes[i].Execute(owner) == Result.running)
            {
                return previousResult = Result.running;
            }
            
        }
        return previousResult = Result.success;
    }
}