using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequencer : Node {
    public override Result Execute(Enemy owner)
    {
        for (int i = 0; i < nodes.Count; i++)
        {
            if (nodes[i].Execute(owner) == Result.failure)
            {
                return Result.failure;
            }

            if (nodes[i].Execute(owner) == Result.running)
            {
                nodes[i].Execute(owner);
                return Result.running;
            }
        }
        return Result.success;
    }
}