using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Howl : Node
{
    public override Result Execute(Enemy owner)
    {
        float randomSpawn = Random.Range(0, 100);

        if (randomSpawn <= 10)
        {
            //Spawn another wolf
            //Play sound effect
            Debug.Log("Wolf spawns due to howl");
            return Result.success;
        }

        return Result.success;
    }
}
