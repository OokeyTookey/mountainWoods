using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FamousQuote : MonoBehaviour
{
    public CanvasGroup canvas;
    float timer;
    bool waitASec;
    TreeChange colourChangeTree;

    private void Start()
    {
        canvas.alpha = 0;
        colourChangeTree = GameObject.FindGameObjectWithTag("starterIsland").GetComponent<TreeChange>();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (waitASec)
        {
            if (timer >= 5)
            {
                StartCoroutine(FadePanelOut());
                timer = 0;
                waitASec = false;
                colourChangeTree.PuzzleComplete();
                gameObject.GetComponent<BoxCollider>().enabled = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(FadePanelIn());
            waitASec = true;
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
