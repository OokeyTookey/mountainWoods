using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : Node {

    public override Result Execute(Enemy owner)
    {
        for (int i = 0; i < nodes.Count; i++)
        {
            if (nodes[i].Execute(owner) == Result.success)
            {
                return Result.success;
            }

            if (nodes[i].Execute(owner) == Result.running)
            {
                return Result.running;
            }
        }
        return Result.failure;
    }
}