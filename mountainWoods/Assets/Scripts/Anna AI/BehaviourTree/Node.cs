using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NSBehaviourTree
{
    public class Node : MonoBehaviour
    {
        public List<Node> nodes = new List<Node>();

        public bool success;
        public bool failure;
        public bool returning;
    }
}