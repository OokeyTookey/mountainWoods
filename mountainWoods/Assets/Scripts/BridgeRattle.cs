using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeRattle : MonoBehaviour {

    float angle;
    float startAngle = 1.11f;
    float endAngle = 10.5f;
    float angleToGo = 0;

    float time = 0;
    int i = 1;

    private void Start()
    {
        angle = transform.rotation.z;
        angleToGo = startAngle;
    }

    private void Update()
    {
        time += Time.deltaTime;

        if(time > 2.0f)
        {
            i *= -1;

            if (i > 0)
                angleToGo = startAngle;
            else
                angleToGo = endAngle;

            time = 0;
        }

     
            angle = Mathf.Lerp(angle, angleToGo, Time.deltaTime);


        transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, angle));
    }

    private void OnCollisionEnter(Collision collision)
    {
        /*if (collideswithplayer)
        {
           
            
        }*/
    }
}
