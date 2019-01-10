using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChasing : MonoBehaviour {
    public Transform player;
	// Use this for initialization
	void Start ()
    {
		
	}
	// Update is called once per frame
	void Update ()
    {
		if(Vector3.Distance(player.position,this.transform.position) < 7)
        {
            Vector3 dir = player.position - this.transform.position;
            dir.y = 0;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(dir), 0.1f);

            if(dir.magnitude > 3)
            {
                this.transform.Translate(0, 0, 0.05f);
            }
        }
	}
}
