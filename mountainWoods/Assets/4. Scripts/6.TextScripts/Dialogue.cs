using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public GameObject Dbox1;
    public GameObject Dbox2;

    private void OnTriggerEnter(Collider other)
    {
        Dbox1.SetActive(true);

    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.Space) && Dbox2 == true)
        {
            Dbox2.SetActive(false);
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            print("test");
            Dbox1.SetActive(false);
            Dbox2.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Dbox1.SetActive(false);
        Dbox2.SetActive(false);
    }
}