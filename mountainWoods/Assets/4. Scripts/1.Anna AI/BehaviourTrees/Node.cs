using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node 
{
    public List<Node> nodes = new List<Node>();


    public enum Result { running, success, failure } //Enum of the different states which each node can have

    public Result previousResult;

    public virtual Result Execute(Enemy owner)
    {
        return Result.running; //If the previous state/mode is running th
    }
}