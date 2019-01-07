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

    public override Result Execute(Enemy owner)
    {
        
        if (Vector3.Distance(otherTransform.position, owner.transform.position) < range) 
        {
           //owner.enemyRB.velocity = Vector3.zero;
            Debug.Log("inRange");

            if (nodes.Count > 0)
            {
            nodes[nodes.Count-1].Execute(owner);

            }
            return Result.running;
        }

        else return Result.failure;
    }
}