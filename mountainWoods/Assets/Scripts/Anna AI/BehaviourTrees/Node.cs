using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public List<Node> nodes = new List<Node>();

    public enum Result { running, success, failure }
    protected Result result; //Can only access it if the class is inheriting from it.

    public virtual void Execute(Enemy owner)
    {

    }
}