using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander1 : Node
{
    Vector3 displacement;
    float timer;
    public Vector3 circleCenter;

    public override Result Execute(Enemy owner)
    {
        timer += Time.deltaTime;

        if (timer > 3)
        {
            circleCenter = owner.enemyRB.velocity.normalized * owner.offset + owner.transform.position; //Creates the circle center in relation to the enemies position
            displacement = circleCenter + new Vector3(Random.Range(-100, 100), 0, Random.Range(-100, 100)).normalized * owner.circleRadius;

            // displacement.y = owner.transform.position.y;
            Debug.Log(displacement);

            owner.transform.LookAt(displacement);
            timer = 0;
        }
        owner.Seek(displacement);
        //Debug.Log("wander");
        return Result.success;
    }
}