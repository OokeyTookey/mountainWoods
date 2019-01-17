using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PNode : MonoBehaviour
{

    // Use this for initialization
    public abstract class TreeNode
    {
        public abstract void Init(Hashtable data);
        public abstract NodeStatus Tick();
    }

    public enum NodeStatus
    {
        Success, Failure, Running
    }
}
