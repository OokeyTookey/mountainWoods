using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform playerReference;
    Node parentNode; //Parent node/link
    
    private void Start()
    {
        parentNode = new Selector();
    }

    public void Update()
    {
        parentNode.Execute(this);  
    }
}
