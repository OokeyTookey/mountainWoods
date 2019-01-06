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
                Debug.Log("Sequence failure");
                return Result.failure;
            }

            if (nodes[i].Execute(owner) == Result.running)
            {
                Debug.Log("Sequence running");
                return Result.running;
            }
        }
        Debug.Log("Sequence succsufyl");
        return Result.success;
    }
}