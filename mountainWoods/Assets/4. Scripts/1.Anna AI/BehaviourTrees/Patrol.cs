using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : Node
{
    bool chooseRandomPosition;
    float randomPositionX;
    float randomPositionZ;

    public override Result Execute(Enemy owner)
    {
        if (!chooseRandomPosition)
        {
            randomPositionX = Random.Range(0, 100);
            randomPositionZ = Random.Range(0, 100);
            chooseRandomPosition = true;
        }

        Vector3 randomLocation = new Vector3(randomPositionX, 0, randomPositionZ);

        owner.Seek(randomLocation * owner.force);

        Debug.DrawLine(owner.transform.position, randomLocation + owner.transform.position, Color.yellow);

        //owner.enemyRB.AddForce((Vector3.forward) * owner.force);
        Debug.Log("Patrol" + owner.enemyRB.velocity);
        return Result.success;
    }
}