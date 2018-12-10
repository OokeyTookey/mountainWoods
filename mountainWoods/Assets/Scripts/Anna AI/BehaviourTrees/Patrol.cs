using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : Node
{
    public override Result Execute(Enemy owner)
    {
        base.Execute(owner);
        owner.gameObject.transform.Translate(Vector3.forward);
        return Result.success;
    }
}