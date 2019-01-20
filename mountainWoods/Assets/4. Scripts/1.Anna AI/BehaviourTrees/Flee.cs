using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee : Node
{
    Vector3 steering;
    Vector3 desiredVelo;
    float distanceFromFlee;
    float poopTimer;
    bool runCoRoute = true;
    List<GameObject> poopList = new List<GameObject>();

    public override Result Execute(Enemy owner)
    {
        poopTimer += Time.deltaTime;

        if (poopTimer >= 3)
        {
            poopList.Add(Object.Instantiate(owner.poopPrefabulous, owner.transform.position, Quaternion.identity));
            poopTimer = 0;
        }

        Debug.Log("Flee");
        Debug.DrawLine(owner.transform.position, owner.enemyRB.velocity + owner.transform.position, Color.yellow); //Debug purposes

        owner.maxSpeed = 15;
        distanceFromFlee = (owner.transform.position - owner.playerReference.position).magnitude; //Calculates the distance between the sheep and position
        desiredVelo = (owner.transform.position - owner.playerReference.position).normalized * owner.maxSpeed; //Get the desired velocity for flee by minusing the target positions (in this case the player) from the attached objects position
        desiredVelo.y = 0;

        if (distanceFromFlee > owner.slowingRadius)
        {
            desiredVelo = Vector3.zero; //Slows down the enemy aka arrival
        }

        steering = desiredVelo - owner.enemyRB.velocity; //Sets the steering behaviour by minusing
        var velocity = Vector3.ClampMagnitude(owner.enemyRB.velocity, 3);
        velocity.y = 0;
        owner.enemyRB.velocity = new Vector3(0, owner.enemyRB.velocity.y, 0) +velocity; //Clamps the magnitude of the enemy
        owner.enemyRB.AddForce(steering * owner.force); //Moves the character based on the set steering behaviour
    
        owner.transform.forward = Vector3.Lerp(owner.transform.forward, velocity, Time.deltaTime);

        if (runCoRoute)
        {
            owner.StartCoroutine(PoopRemover());
            Debug.Log("Ran");
            runCoRoute = false;
        }

        return previousResult = Result.success;
    }

    IEnumerator PoopRemover()
    {
        while (true)
        {
            Debug.Log("Running");

            if (poopList.Count > 0)
            {
                Debug.Log("Removing ");
                Object.Destroy(poopList[0]);
                poopList.RemoveAt(0);
            }
            yield return new WaitForSeconds(10);
        }
    }
}