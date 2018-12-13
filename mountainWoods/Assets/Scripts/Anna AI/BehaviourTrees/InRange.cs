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
        if (Vector3.Distance(otherTransform.position, owner.transform.position) < range) //Checks distance
        {
            return Result.success; 
        }

        else return Result.failure; 
    }
}