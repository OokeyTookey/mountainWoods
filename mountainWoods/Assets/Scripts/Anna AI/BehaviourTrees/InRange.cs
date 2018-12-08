using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InRange : Node
{
    public Transform otherPosition;
    public float range;

    public override void Execute(Enemy owner)
    {
        if (Vector3.Distance(otherPosition.position, owner.transform.position) < range)
        {
            result = Result.success;
        }

        else result = Result.failure;
        base.Execute(owner);
    }
}