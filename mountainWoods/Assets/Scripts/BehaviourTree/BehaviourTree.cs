using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NSBehaviourTree
{
    public class BehaviourTree : MonoBehaviour
    {
        Node parentNode = new Node();
        int index = 0;

        int Index
        {
            get
            {
                return index;
            }

            set
            {
                if(value <= parentNode.nodes.Count -1)
                    index = value;
            }
        }

        void Start()
        {
          /*  parentNode.nodes.Add(new Eat());
            parentNode.nodes.Add(new Drink());
            parentNode.nodes.Add(new Open());
            parentNode.nodes.Add(new Die());

            ((Eat)parentNode.nodes[0]).Behaviour();*/
        }

        void Update()
        {
            //Debug.Log(Index);

            /*if (parentNode.nodes[Index].success)
            {
                Index++;
            }

            else if (parentNode.nodes[Index].failure)
            {
                parentNode.failure = true;
            }*/

            /*Debug.Log("<color=green> sucess </color>"+ parentNode.success);
            Debug.Log("<color=red> fairure </color> " + parentNode.failure);*/
           // Debug.Log(parentNode.returning);
        }
    }
}
