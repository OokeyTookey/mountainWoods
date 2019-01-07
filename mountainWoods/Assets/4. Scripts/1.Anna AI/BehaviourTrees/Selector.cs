using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : Node {

    public override Result Execute(Enemy owner)
    {
        for (int i = 0; i < nodes.Count; i++)
        {
            if (previousResult == Result.running && nodes[i].previousResult != Result.running)
            {
                continue; //Skips an itteration in the for loops
            }

            if (nodes[i].Execute(owner) == Result.success)
            {
                return previousResult = Result.success;
            }

            if (nodes[i].Execute(owner) == Result.running)
            {
                return previousResult = Result.running;
            }
        }
        return previousResult = Result.failure;
    }
}