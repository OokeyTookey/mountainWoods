using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float range;
    public Transform playerReference;
    Node parentNode; //Parent node/link

    private void Start()
    {
        parentNode = new Selector();
        parentNode.nodes.Add(new InRange(playerReference, range));
        parentNode.nodes.Add(new Patrol());
    }

    public void Update()
    {
        parentNode.Execute(this);  
    }
}