using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandGround : Node {

    int counter;
    float distanceFromPlayer;

    public override Result Execute(Enemy owner)
    {
        distanceFromPlayer = (owner.playerReference.position - owner.transform.position).magnitude; //Calculates the distance between the sheep and position

        if (distanceFromPlayer <= owner.lineOfSight)
        {
            counter++;
            owner.enemyRB.velocity = Vector3.zero; //makes the wolf stand still :)
        }

        if (counter == 3)
        {
            counter = 0;
            return Result.success;
        }

        return Result.failure;
    }
}