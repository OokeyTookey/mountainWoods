using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandGround : Node {

    int counter;
    float distanceFromPlayer;
    float waitTimer; 

    public override Result Execute(Enemy owner)
    {
        owner.enemyRB.velocity = Vector3.zero; //makes the wolf stand still :)

        waitTimer += Time.deltaTime;

        if (waitTimer >= 30)
        {
            Debug.Log("<color=red> Stand ground </color>");
            return previousResult = Result.success;
        }
        return previousResult = Result.failure;
    }
}