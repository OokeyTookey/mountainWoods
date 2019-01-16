using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InRange : Node
{
    float range;
    Transform otherTransform;

    public InRange(Transform otherTranformPosition, float range)
    {
        otherTransform = otherTranformPosition;
        this.range = range;
    }

    public override Result Execute(Enemy owner) //Conditional node, becomes invisible when sucessful.
    {
        if (Vector3.Distance(otherTransform.position, owner.transform.position) < range)
        {
            Debug.Log("inRange");
            return nodes[nodes.Count - 1].Execute(owner);
        }

        else return previousResult = Result.failure;
    }
}