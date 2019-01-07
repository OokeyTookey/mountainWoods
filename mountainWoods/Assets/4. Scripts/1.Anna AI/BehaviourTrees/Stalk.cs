using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalk : Node
{
    float angleFromPlayer;
    Vector3 angletowardsEnemy;

    public override Result Execute(Enemy owner)
    {
        angletowardsEnemy = (owner.transform.position - owner.playerReference.position).normalized; //Gets the position of the enemy and player to calculate the angle.
        angleFromPlayer =  Vector3.Angle(owner.playerReference.forward, angletowardsEnemy); //angle between the two vectors (vectors are stored at 0,0)
        
        if (angleFromPlayer < owner.FOV) //choose range distance check
        {
            return previousResult =  Result.failure; //If the wolf fails then it will run the sequencer
        }
        owner.Seek(owner.playerReference.position); // the problem 

        //Make it so that if the player doesnt notice the wolf and the wolf touches him, teleports the player back to the start/recent checkpoint?
        return previousResult =  Result.success;
    }
}