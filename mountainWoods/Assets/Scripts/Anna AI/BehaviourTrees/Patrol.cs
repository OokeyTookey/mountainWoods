using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : Node
{
    public override void Execute(Enemy owner)
    {
        base.Execute(owner);
        owner.gameObject.transform.Translate(Vector3.forward);
    }
}
