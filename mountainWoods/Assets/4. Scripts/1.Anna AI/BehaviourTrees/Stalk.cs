using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalk : Node
{
    public override Result Execute(Enemy owner)
    {
        owner.Seek(owner.playerReference.position);
        Debug.Log("Stalk");
        // always stay behind the player?
        return Result.success;
    }
}