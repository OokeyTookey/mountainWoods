using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfPatrol : MonoBehaviour {

    int index;
    float force = 4;
    public GameObject[] wolfLocations;
    public GameObject playerReference;
    public GameObject youGotBit;
    public CanvasGroup canvas;
    public GameObject sendPlayerBack;
    public bool followPlayer;
    Vector3 offtset;
    Rigidbody wolfRB;
    float timer;
    bool waitToTele;

    private void Start()
    {
        canvas.alpha = 0;
    }

    void Update ()
    {
        timer += Time.deltaTime;
        offtset = new Vector3(playerReference.transform.position.x, playerReference.transform.position.y, playerReference.transform.position.z);

        if (waitToTele)
        {
            if (timer >= 3)
            {
                timer = 0;
                waitToTele = false;
                StartCoroutine(FadePanelOut());
            }
        }

        if (Vector3.Distance(transform.position, wolfLocations[index].transform.position) <= 1)
        {
            if (index < wolfLocations.Length - 1)
            {
                index++;
            }
            else index = 0;
        }

        if (!followPlayer)
        {
            transform.LookAt(wolfLocations[index].transform.position);
            transform.position = Vector3.MoveTowards(transform.position, wolfLocations[index].transform.position, Time.deltaTime); //Moves towards the temp current waypoint
        }

        if (followPlayer)
        {
            transform.LookAt(offtset);
            transform.position = Vector3.MoveTowards(transform.position, playerReference.transform.position, Time.deltaTime * force);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            followPlayer = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(FadePanelIn());
            followPlayer = false;
            //youGotBit.SetActive(true);
            playerReference.transform.position = sendPlayerBack.transform.position;
            Debug.Log("heywecollided");
            waitToTele = true;
            timer = 0;
        }
   }

    private IEnumerator FadePanelIn()
    {
        float percentage = 0;
        while (percentage < 1)
        {
            percentage += 0.05f;
            canvas.alpha = percentage;
            yield return new WaitForSeconds(0.1f);
        }
    }

    private IEnumerator FadePanelOut()
    {
        float percentage = 1;
        while (percentage > 0)
        {
            percentage -= 0.05f;
            canvas.alpha = percentage;
            yield return new WaitForSeconds(0.1f);
        }
    }
}


