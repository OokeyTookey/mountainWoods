using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour {
    GameObject DMenu;
    GameObject Farmer;
    // Use this for initialization
    void Start () {
        
	}

    // Update is called once per frame
    void Update() {
    }

    void OnCollisionEnter(Collision collision)
    {
        DMenu.SetActive(true);  
    }
    private void OnCollisionExit(Collision collision)
    {
        DMenu.SetActive(false);
    }

}
