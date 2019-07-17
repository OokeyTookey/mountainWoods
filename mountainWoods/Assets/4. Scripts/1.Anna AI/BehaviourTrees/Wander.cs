using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : Node
{
    Vector3 displacement;
    public Vector3 circleCenter;
    float timer = 4;

    public override Result Execute(Enemy owner)
    {
        timer += Time.deltaTime;

        if (timer > 1)
        {
            owner.maxSpeed = 1.5f;
            circleCenter = owner.enemyRB.velocity.normalized * owner.offset + owner.transform.position; //Creates the circle center in relation to the enemies position
            circleCenter.y = owner.transform.position.y;
            displacement = circleCenter + new Vector3(Random.Range(-100, 100), 0, Random.Range(-100, 100)).normalized * owner.circleRadius;
            timer = 0;
        }
        owner.Seek(new Vector3(displacement.x, owner.transform.position.y, displacement.z));
        return Result.success;
    }
}