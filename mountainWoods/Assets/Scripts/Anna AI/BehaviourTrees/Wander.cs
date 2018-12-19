using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : Node
{
    //----------- Wander Vairables
    Vector3 displacement;

    public Vector3 circleCenter;
   
   public override Result Execute(Enemy owner)
    {
        circleCenter = owner.enemyRB.velocity.normalized * owner.offset + owner.transform.position;
        displacement = circleCenter + new Vector3(Random.Range(-100, 100), 0, Random.Range(-100, 100)).normalized * owner.circleRadius;
        owner.Seek(displacement);
        Debug.Log("wander");
       // print(owner.enemyRB.velocity);
        return Result.success;
    }
}