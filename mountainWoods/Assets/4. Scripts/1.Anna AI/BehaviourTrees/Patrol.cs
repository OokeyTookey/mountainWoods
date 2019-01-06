using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : Node
{
    public override Result Execute(Enemy owner)
    {
        //choose random position
        //seek to that position

        /*float randomPositionX = Random.Range(0, 100);
        float randomPositionZ = Random.Range(0, 100);

        Vector3 randomLocation = new Vector3(randomPositionX, 0, randomPositionZ);

        owner.Seek(owner.playerReference.position);

        Debug.DrawLine(owner.transform.position, randomLocation + owner.transform.position, Color.yellow);*/

        owner.enemyRB.AddForce(Vector3.forward);
        Debug.Log("Patrol");
        return Result.success;
    }
}