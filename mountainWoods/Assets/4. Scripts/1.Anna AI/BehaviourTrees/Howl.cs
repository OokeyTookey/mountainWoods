using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Howl : Node
{
    bool hasWolfHowled;

    public override Result Execute(Enemy owner)
    {
        if (!hasWolfHowled)
        {
            float randomSpawn = Random.Range(0, 100);

            if (randomSpawn <= 1)
            {
                //Spawn another wolf
                //Play sound effect
                Debug.Log("Wolf Spawns: Howl");
                return previousResult = Result.success;
            }
            hasWolfHowled = true;
        }
        return previousResult = Result.success;
    }
}